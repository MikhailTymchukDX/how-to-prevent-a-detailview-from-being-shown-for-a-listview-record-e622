using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using System.Reflection;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;


namespace WinWebSolution.Module {
	public interface IModelDefaultShowDetailView : IModelNode {
		[DefaultValue(true)]
		bool DefaultShowDetailViewFromListView { get; set; }
	}
	public interface IModelShowDetailView : IModelNode {
		bool ShowDetailView { get; set; }
	}
	[DomainLogic(typeof(IModelShowDetailView))]
	public static class ModelShowDetailViewLogic {
		public static bool Get_ShowDetailView(IModelShowDetailView showDetailView) {
			IModelDefaultShowDetailView defaultShowDetailViewFromListView = showDetailView.Parent as IModelDefaultShowDetailView;
			if(defaultShowDetailViewFromListView != null) {
				return defaultShowDetailViewFromListView.DefaultShowDetailViewFromListView;
			}
			return true;
		}
	}

    public sealed partial class WinWebSolutionModule : ModuleBase {
        public WinWebSolutionModule() {
            InitializeComponent();
        }
		public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders) {
			base.ExtendModelInterfaces(extenders);
			extenders.Add<IModelViews, IModelDefaultShowDetailView>();
			extenders.Add<IModelListView, IModelShowDetailView>();
		}
    }
}
