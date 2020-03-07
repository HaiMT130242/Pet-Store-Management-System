﻿using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace PetStore.Views.PetFoodView{
    public partial class PetFoodView : XtraUserControl {
        public PetFoodView() {
            InitializeComponent();
			if(!mvvmContext.IsDesignMode)
				InitBindings();
		}
		void InitBindings() {
		    var fluentAPI = mvvmContext.OfType<PetStore.ViewModels.PetFoodViewModel>();
			fluentAPI.WithEvent(this, "Load").EventToCommand(x => x.OnLoaded());
            fluentAPI.SetObjectDataSourceBinding(
                petFoodViewBindingSource, x => x.Entity, x => x.Update());
						#region BillDetails Detail Collection
			// We want to synchronize the ViewModel.SelectedEntity and the GridView.FocusedRowRandle in two-way manner
            fluentAPI.WithEvent<GridView, FocusedRowObjectChangedEventArgs>(BillDetailsGridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.PetFoodBillDetailsDetails.SelectedEntity,
                    args => args.Row as PetStore.BillDetail,
                    (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
						//We want to show PopupMenu when row clicked by right button
			BillDetailsGridView.RowClick += (s, e) => {
                if(e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Right) {
                    BillDetailsPopUpMenu.ShowPopup(BillDetailsGridControl.PointToScreen(e.Location), s);
                }
            };
			// We want to show the PetFoodBillDetailsDetails collection in grid and react on this collection external changes (Reload, server-side Filtering)
			fluentAPI.SetBinding(BillDetailsGridControl, g => g.DataSource, x => x.PetFoodBillDetailsDetails.Entities);
				
														fluentAPI.BindCommand(bbiBillDetailsRefresh, x => x.PetFoodBillDetailsDetails.Refresh());
																	#endregion
									// Binding for Type LookUp editor
			fluentAPI.SetBinding(TypeLookUpEdit.Properties, p => p.DataSource, x => x.LookUpTypes.Entities);
			 
			bbiCustomize.ItemClick += (s, e) => { dataLayoutControl1.ShowCustomizationForm(); };
       }
    }
}