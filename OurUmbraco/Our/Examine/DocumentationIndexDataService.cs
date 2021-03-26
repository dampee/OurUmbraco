using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using Examine;
using Examine.LuceneEngine;
using System;
using Umbraco.Core.Logging;
using System.Linq;

namespace OurUmbraco.Our.Examine
{
    /// <summary>
    /// Used to index the documentation 
    /// </summary>
    public class DocumentationIndexDataService : ISimpleDataService
    {

        public IEnumerable<SimpleDataSet> GetAllData(string indexType)
        {
            var config = DocumentationIndexConfig.Settings;
            var fullPath = HostingEnvironment.MapPath(config.DirectoryToIndex);

            var directory = new DirectoryInfo(fullPath);

            var files = config.Recursive
                ? directory.GetFiles(config.SupportedFileTypes, SearchOption.AllDirectories)
                : directory.GetFiles(config.SupportedFileTypes);

            var i = 0; //unique id for each doc


            const string DocumentationFolder = @"~\Documentation";
            string _rootFolderPath = HostingEnvironment.MapPath(DocumentationFolder);

            if (Directory.Exists(_rootFolderPath) == false || !Directory.Exists(Path.Combine(_rootFolderPath, ".git")))
            {
                LogHelper.Error(typeof(DocumentationIndexDataService), "could not find documentation repository", new InvalidOperationException());
                yield break;
            }

            using (var repo = new LibGit2Sharp.Repository(_rootFolderPath))
            {
                var repoCommits = repo.Commits.ToList();
                repoCommits.Where(c=>c.Notes.First().BlobId)

                foreach (var file in files)
                {
                    i++;
                    var simpleDataSet = new SimpleDataSet { NodeDefinition = new IndexedNode(), RowData = new Dictionary<string, string>() };

                    try
                    {
                        simpleDataSet = ExamineHelper.MapFileToSimpleDataIndexItem(repo, file, simpleDataSet, i, indexType);
                    }
                    catch (Exception ex)
                    {
                        Umbraco.Core.Logging.LogHelper.Error<DocumentationIndexDataService>(
                            $"Indexing docs - could not parse document {file.FullName}", ex);
                        if (System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();
                    }
                    yield return simpleDataSet;
                }
                Umbraco.Core.Logging.LogHelper.Info<DocumentationIndexDataService>(
                            $"Indexed documentation files: {0}", () => files.Length);
            }
        }
    }
}
