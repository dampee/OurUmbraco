﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using OurUmbraco.Community.Models;
using OurUmbraco.Our.Api;
using RestSharp;
using Umbraco.Core.Cache;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace OurUmbraco.Community.Controllers
{
    public class GitHubContributorController : SurfaceController
    {
        public ActionResult GitHubGetContributorsResult()
        {
            var model = new GitHubContributorsModel();
            try
            {
                var contributors = ApplicationContext.ApplicationCache.RuntimeCache.GetCacheItem<List<GitHubContributorModel>>("UmbracoGitHubContributors",
                    () =>
                    {
                        //TODO: GitHub keys if required
                        var githubController = new GitHubController();
                        var response = githubController.GetAllContributors();
                        if (response.StatusCode == HttpStatusCode.OK && response.ResponseStatus == ResponseStatus.Completed)
                        {
                            return response.Data;
                        }
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }, TimeSpan.FromMinutes(2));

                var filteredContributors = contributors;
                //TODO: filter contributors
                model.Contributors = filteredContributors;
            }
            catch (Exception ex)
            {
                LogHelper.Error<IGitHubContributorsModel>("Could not get GitHub Contributors", ex);
            }
            
            return PartialView("~/Views/Partials/Home/GitHubContributors.cshtml", model);
        }
    }
}
