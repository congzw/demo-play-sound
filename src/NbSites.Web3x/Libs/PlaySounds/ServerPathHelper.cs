using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace NbSites.Web.Libs.PlaySounds
{
    public class ServerPathHelper
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ServerPathHelper(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// default => map to "~/wwwroot/"
        /// </summary>
        public string WebRootPath => _hostingEnvironment.WebRootPath;

        /// <summary>
        /// default => map to "~/"
        /// </summary>
        public string ContentRootPath => _hostingEnvironment.ContentRootPath;


        /// <summary>
        /// 映射：相对路径 => 绝对路径 map to "~/wwwroot/"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string MapWebRootPath(string path)
        {
            return MapPath(WebRootPath, path);
        }

        /// <summary>
        /// 映射：相对路径 => 绝对路径 map to "~/"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string MapContentRootPath(string path)
        {
            return MapPath(ContentRootPath, path);
        }
        
        private string MapPath(string basePath, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return basePath;
            }
            var thePaths = new List<string>();
            thePaths.Add(basePath);
            var subPaths = path.TrimStart('~').TrimStart('/').Split('/', StringSplitOptions.RemoveEmptyEntries);
            thePaths.AddRange(subPaths);
            return Path.Combine(thePaths.ToArray());
        }
    }
}