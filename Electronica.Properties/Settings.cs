using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Electronica.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => defaultInstance;

		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		[SpecialSetting(SpecialSetting.ConnectionString)]
		[DefaultSettingValue("server=localhost;user id=root;database=electronicax;persistsecurityinfo=True")]
		public string electronicaxConnectionString
		{
			get
			{
				return (string)this["electronicaxConnectionString"];
			}
		}

		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		[SpecialSetting(SpecialSetting.ConnectionString)]
		[DefaultSettingValue("server=localhost;user id=root;database=electronicax;allowuservariables=True")]
		public string electronicaxConnectionString1
		{
			get
			{
				return (string)this["electronicaxConnectionString1"];
			}
		}
	}
}
