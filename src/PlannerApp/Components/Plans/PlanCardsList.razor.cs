using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.JSInterop;
using PlannerApp;
using PlannerApp.Shared;
using PlannerApp.Components;
using MudBlazor;
using Blazored.FluentValidation;
using PlannerApp.Shared.Models;

namespace PlannerApp.Components
{
    public partial class PlanCardsList
    {

        private bool _isBusy { get; set; }
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private string _query = string.Empty;

        [Parameter]
        public Func<string, int, int, Task<PagedList<PlanSummary>>> FetchPlans { get; set; }

        private PagedList<PlanSummary> _result = new();

        protected async override Task OnInitializedAsync()
        {
            _isBusy = true;
            _result = await FetchPlans?.Invoke(_query, _pageNumber, _pageSize);
            _isBusy = false; 
        }

    }
}