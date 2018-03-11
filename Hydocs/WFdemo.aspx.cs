using System;
using System.Web.UI.WebControls;

namespace Hydocs
{
    public partial class WFdemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            var item = e.InputParameters;
        }

        

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            var item = e.InputParameters;
        }

        protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            var item = e.NewEditIndex;
        }
    }
}
