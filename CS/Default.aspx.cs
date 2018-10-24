using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        ASPxGridView1.DataSource = Enumerable.Range(0, 10).Select(i => new {
            ID = i,
            ClientSideCancel = "Example " + i,
            SampleColumn = "Sample data " + i,
            ServerSideExample = i * 123
        });
        ASPxGridView1.DataBind();
    }
    protected void ASPxGridView1_CustomJSProperties(object sender, DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs e) {
        var clientData = new Dictionary<int, object>();
        var grid = sender as ASPxGridView;
        for (int i = grid.VisibleStartIndex; i < grid.VisibleStartIndex + grid.SettingsPager.PageSize; i++) {
            var rowValues = grid.GetRowValues(i, new string[] { "ID", "ServerSideExample" }) as object[];

            var key = Convert.ToInt32(rowValues[0]);
            if (key % 2 != 0)
                clientData.Add(key, "ServerSideExample");
        }
        e.Properties["cp_cellsToDisable"] = clientData;
    }
}