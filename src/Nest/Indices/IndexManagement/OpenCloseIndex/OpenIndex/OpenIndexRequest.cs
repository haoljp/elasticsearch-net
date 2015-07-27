﻿using System;
using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IOpenIndexRequest : IIndexPath<OpenIndexRequestParameters> { }

	internal static class OpenIndexPathInfo
	{
		public static void Update(ElasticsearchPathInfo<OpenIndexRequestParameters> pathInfo, IOpenIndexRequest request)
		{
			pathInfo.HttpMethod = HttpMethod.POST;
		}
	}
	
	public partial class OpenIndexRequest : IndexPathBase<OpenIndexRequestParameters>, IOpenIndexRequest
	{
		public OpenIndexRequest(IndexName index) : base(index) { }

		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<OpenIndexRequestParameters> pathInfo)
		{
			OpenIndexPathInfo.Update(pathInfo, this);
		}
	}

	[DescriptorFor("IndicesOpen")]
	public partial class OpenIndexDescriptor : IndexPathDescriptorBase<OpenIndexDescriptor, OpenIndexRequestParameters>, IOpenIndexRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<OpenIndexRequestParameters> pathInfo)
		{
			OpenIndexPathInfo.Update(pathInfo, this);
		}
	}
}