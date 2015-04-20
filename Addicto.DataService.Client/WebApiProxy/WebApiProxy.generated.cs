//This file is auto-generated by WebApiProxy
//Any changes to this file will be overwritten
//Project site: http://github.com/faniereynders/webapiproxy

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Linq;
using System.Net;
using System.Web;
using Addicto.DataService.Client.Proxies.Models;

#region Proxies
namespace Addicto.DataService.Client.Proxies
{
	/// <summary>
	/// Client configuration.
	/// </summary>
	public partial class Configuration
	{
		/// <summary>
		/// Web Api Base Address.
		/// </summary>
		public static string MyWebApiProxyBaseAddress = "http://localhost:86";
		
	}
}
#endregion

#region Models
namespace Addicto.DataService.Client.Proxies.Models
{
	public class WebApiProxyResponseException : Exception
	{
		public HttpStatusCode StatusCode { get; private set; }
		public string Content { get; private set; }

		public WebApiProxyResponseException(HttpStatusCode statusCode, string content) : base("A " + statusCode + " (" + (int)statusCode + ") http exception occured. See Content for response body.")
		{
			StatusCode = statusCode;
			Content = content;
		}
	}


	
}
#endregion

#region Interfaces
namespace Addicto.DataService.Client.Proxies.Interfaces
{
	public interface IClientBase : IDisposable
	{
		HttpClient HttpClient { get; }
	}

	
	public partial interface IArticlesClient : IClientBase
	{	

		/// <param name="id"></param>
		/// <returns></returns>
		Task<HttpResponseMessage> GetAsync(Int32 id);

		/// <param name="id"></param>
		/// <returns></returns>
		String Get(Int32 id);

		/// <param name="query"></param>
		/// <returns></returns>
		Task<HttpResponseMessage> GetAsync(String query);

		/// <param name="query"></param>
		/// <returns></returns>
		String Get(String query);

		/// <returns></returns>
		Task<HttpResponseMessage> PostAsync(String value);

		/// <returns></returns>
		void Post(String value);

		/// <param name="id"></param>
		/// <returns></returns>
		Task<HttpResponseMessage> PutAsync(Int32 id,String value);

		/// <param name="id"></param>
		/// <returns></returns>
		void Put(Int32 id,String value);

		/// <param name="id"></param>
		/// <returns></returns>
		Task<HttpResponseMessage> DeleteAsync(Int32 id);

		/// <param name="id"></param>
		/// <returns></returns>
		void Delete(Int32 id);
				
	}

}
#endregion

#region Clients
namespace Addicto.DataService.Client.Proxies.Clients
{
	/// <summary>
	/// Client base class.
	/// </summary>
	public abstract partial class ClientBase : IDisposable
	{
		/// <summary>
		/// Gests the HttpClient.
		/// </summary>
		public HttpClient HttpClient { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientBase"/> class.
		/// </summary>
		protected ClientBase()
		{
			HttpClient = new HttpClient()
			{
				BaseAddress = new Uri(Configuration.MyWebApiProxyBaseAddress)
			};
		}

		public virtual void EnsureSuccess(HttpResponseMessage response)
		{			
			if (response.IsSuccessStatusCode)				
				return;
													
			var content = response.Content.ReadAsStringAsync().Result;
			throw new WebApiProxyResponseException(response.StatusCode, content);			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClientBase"/> class.
		/// </summary>
		/// <param name="handler">The handler.</param>
		/// <param name="disposeHandler">if set to <c>true</c> [dispose handler].</param>
		protected ClientBase(HttpMessageHandler handler, bool disposeHandler = true)
		{
			HttpClient = new HttpClient(handler, disposeHandler)
			{
				BaseAddress = new Uri(Configuration.MyWebApiProxyBaseAddress)
			};
		}

		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources.       
		/// </summary>
		public void Dispose()
		{
			HttpClient.Dispose();
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public partial class ArticlesClient : ClientBase, Interfaces.IArticlesClient
	{		

		/// <summary>
		/// 
		/// </summary>
		public ArticlesClient() : base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ArticlesClient(HttpMessageHandler handler, bool disposeHandler = true) : base(handler, disposeHandler)
		{
		}

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync(Int32 id)
		{
			return await HttpClient.GetAsync("api/Articles/" + id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public virtual String Get(Int32 id)
		{
						 var result = Task.Run(() => GetAsync(id)).Result;		 
			 
			EnsureSuccess(result);
				 
			 			 			 
			 return result.Content.ReadAsAsync<String>().Result;
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync(String query)
		{
			return await HttpClient.GetAsync("api/Articles?query=" + query);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		public virtual String Get(String query)
		{
						 var result = Task.Run(() => GetAsync(query)).Result;		 
			 
			EnsureSuccess(result);
				 
			 			 			 
			 return result.Content.ReadAsAsync<String>().Result;
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> PostAsync(String value)
		{
			return await HttpClient.PostAsJsonAsync<String>("api/Articles", value);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Post(String value)
		{
						 var result = Task.Run(() => PostAsync(value)).Result;		 
			 
			EnsureSuccess(result);
				 
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> PutAsync(Int32 id,String value)
		{
			return await HttpClient.PutAsJsonAsync<String>("api/Articles/" + id, value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public virtual void Put(Int32 id,String value)
		{
						 var result = Task.Run(() => PutAsync(id, value)).Result;		 
			 
			EnsureSuccess(result);
				 
			 		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual async Task<HttpResponseMessage> DeleteAsync(Int32 id)
		{
			return await HttpClient.DeleteAsync("api/Articles/" + id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public virtual void Delete(Int32 id)
		{
						 var result = Task.Run(() => DeleteAsync(id)).Result;		 
			 
			EnsureSuccess(result);
				 
			 		}

		#endregion
	}
}
#endregion

