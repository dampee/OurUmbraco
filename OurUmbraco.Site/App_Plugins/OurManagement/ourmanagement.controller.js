﻿angular.module("umbraco").controller("ourManagementController", function ($scope, $http, notificationsService) {
    var vm = this;
    vm.docsLoading = false;
    vm.youTrackLoading = false;

    $scope.getPullRequestStatisticsCms = function () {
        var prDataUrlCms = "backoffice/API/PullRequestStatistics/GetGroupedPullRequestData/?fromDate=2010-01-01&toDate=2030-01-01";

        vm.prStatsCms = [];

        $http.get(prDataUrlCms)
            .success(function (data) {
                vm.prStatsCms = data;

                var lastItem = vm.prStatsCms[vm.prStatsCms.length - 1];
                vm.totalNumberOfContributorsCms = lastItem.TotalNumberOfContributors;
            })
            .error(function () {
                notificationsService.error("Problem retrieving CMS PR statistics data");
            });
    };

    $scope.getPullRequestStatisticsDocs = function () {
        var prDataUrlDocs = "backoffice/API/PullRequestStatistics/GetGroupedPullRequestData/?fromDate=2010-01-01&toDate=2030-01-01&repository=UmbracoDocs";

        vm.prStatsDocs = [];

        $http.get(prDataUrlDocs)
            .success(function (data) {
                vm.prStatsDocs = data;

                var lastItem = vm.prStatsDocs[vm.prStatsDocs.length - 1];
                vm.totalNumberOfContributorsDocs = lastItem.TotalNumberOfContributors;
            })
            .error(function () {
                notificationsService.error("Problem retrieving Documentation PR statistics data");
            });
    };

    $scope.downloadDocumentation = function () {
        vm.docsLoading = false;
        vm.docsMessage = "Downloading documentation, hold on...";
        notificationsService.success(vm.docsMessage);

        var downloadUrl = "/html/githubpulltrigger";
        $http.get(downloadUrl)
            .success(function () {
                vm.docsLoading = false;
                vm.docsMessage = "✔ Documentation all downloaded and indexed.";
                notificationsService.success(vm.docsMessage);
            })
            .error(function () {
                vm.docsLoading = false;
                vm.docsMessage = "❌ Problem with the documentation download/indexing.";
                notificationsService.error(vm.docsMessage);
            });
    };

    $scope.findMember = function (searchTerm) {
        var getMemberSearchUrl = "backoffice/API/Members/SearchMembers/?searchTerm=" + searchTerm;
        $http.get(getMemberSearchUrl)
            .success(function (data) {
                if (data.length === 0) {
                    notificationsService.error("❌ No members found that match the search term(s).");
                }
                if (data.length === 1) {
                    $scope.selectMember(data[0].Key, data[0].Name, data[0].Id);
                } else {
                    vm.memberSearchResults = data;
                }
            })
            .error(function () {
                vm.memberError = "❌ Problem with getting the member search results.";
                notificationsService.error(vm.memberError);
            });
    };

    $scope.selectMember = function (memberKey, memberName, memberId) {
        vm.memberSearchResults = undefined;
        vm.memberId = memberId;
        vm.memberBackofficeUrl = "/umbraco/#/member/member/edit/" + memberKey;
        vm.memberName = memberName;
    };
    
    $scope.addContribBadgeToMember = function (memberId) {
        var getMemberUrl = "backoffice/API/Members/AddContribBadgeToMember/?memberId=" + memberId;
        $http.get(getMemberUrl)
            .success(function (data) {
                if (data === "true") {
                    vm.addBadgeMessage = "✔ " + vm.memberName + " now has a contrib badge.";
                    notificationsService.success(vm.addBadgeMessage);
                } else {
                    notificationsService.error("❌ Problem with adding contrib badge to the member.");
                }
            })
            .error(function () {
                vm.memberError = "❌ Problem with getting the member.";
                notificationsService.error(vm.memberError);
            });
    };

    $scope.downloadYoutrackData = function () {
        vm.youTrackLoading = true;
        vm.youTrackMessage = "Downloading YouTrack data, hold on...";
        notificationsService.success(vm.youTrackMessage);

        var youtrackUrl = "backoffice/API/YouTrackApi/GetData";
        $http.get(youtrackUrl)
            .success(function () {
                vm.youTrackLoading = false;
                vm.youTrackMessage = "✔ YouTrack data all downloaded.";
                notificationsService.success(vm.youTrackMessage);
            })
            .error(function () {
                vm.youTrackLoading = false;
                vm.youTrackMessage = "❌ Problem with the YouTrack data download.";
                notificationsService.error(vm.youTrackMessage);
            });
    };
});
