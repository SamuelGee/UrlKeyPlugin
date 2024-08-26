using System;

using System.IO;
using System.Net;
using System.Windows.Forms;

using KeePass.Plugins;
using KeePassLib;
using KeePassLib.Keys;

namespace UrlKeyPlugin
{
	public sealed class UrlKeyPluginExt : Plugin
	{
		private IPluginHost m_host = null;

		private string[] cfgLines = null;

		private UrlKeyProvider[] m_prov = new UrlKeyProvider[1];

		//constructor
		public UrlKeyPluginExt()
		{
			string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (File.Exists(myDocumentsPath+"\\UrlKeyProvider.cfg")) cfgLines = File.ReadAllLines(myDocumentsPath+"\\UrlKeyProvider.cfg");
			else if (File.Exists("UrlKeyProvider.cfg")) cfgLines = File.ReadAllLines("UrlKeyProvider.cfg");
			else MessageBox.Show("Plugin \"URL Key Provider\" says:\nCannot open UrlKeyProvider.cfg\nin \"My Documents\"\nnor in KeePass.exe directory", "URL Key Provider", 0, MessageBoxIcon.Warning);

			if(cfgLines != null)
			{
				Array.Resize<UrlKeyProvider>(ref m_prov, cfgLines.Length);
				for (int i = 0; i < cfgLines.Length; i++)
				{
					if (cfgLines[i].Substring(0, 1) == "#") continue;
					string[] keys = cfgLines[i].Split(':');
					m_prov[i] = new UrlKeyProvider(keys[0], "https://iowa.root.sx/plugin/"+keys[1]);
				}
			}
		}

		public override bool Initialize(IPluginHost host)
		{
			if(host == null) return false; // Fail; we need the host
			m_host = host;

			if(cfgLines == null) return false; // Fail; we need a config file

			for (int i = 0; i < cfgLines.Length; i++)
			{
				if (cfgLines[i].Substring(0, 1) == "#") continue;
				m_host.KeyProviderPool.Add(m_prov[i]);
			}
			return true; // Initialization successful
		}

		public override void Terminate()
		{
			for (int i = 0; i < cfgLines.Length; i++)
			{
				if (cfgLines[i].Substring(0, 1) == "#") continue;
				m_host.KeyProviderPool.Remove(m_prov[i]);
			}
		}
	}

	public sealed class UrlKeyProvider : KeyProvider
	{
		public string M_name;
		public string M_url;

		public UrlKeyProvider(string m_name, string m_url)
		{
			M_name = m_name;
			M_url = m_url;
		}

		public override string Name
		{
			get { return M_name; }
		}

		public override bool SecureDesktopCompatible
		{
			get { return true; }
		}


		public override byte[] GetKey(KeyProviderQueryContext ctx)
		{
			try
			{
				WebClient client = new WebClient();
				return client.DownloadData(M_url);
			}
			catch (Exception e)
			{
				MessageBox.Show("Cannot connect! (check your internet)");
				return null;
			}

		}
	}

}
