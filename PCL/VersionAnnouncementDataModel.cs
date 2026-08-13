using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PCL;

public class VersionAnnouncementDataModel
{
	[field: CompilerGenerated]
	public List<VersionAnnouncementContentModel> content
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
