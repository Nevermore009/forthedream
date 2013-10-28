using System;
using SMCShine.Logic.Module.GoodsManager;
using SMCShine.Common;

public partial class Module_GoodsManager_GoodsManage : BasePage
{
    private GoodsManager goodsManager = new GoodsManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitgrvGoodsType();
            InitgrvGoodsItem();
        }
    }
    protected void InitgrvGoodsType()
    {
        BindHelper.BindGridview(grvGoodsType, goodsManager.GetGoodsTypeInfoByUser(Campus));
    }

    protected void InitgrvGoodsItem()
    {
        BindHelper.BindGridview(grvGoodsItem, goodsManager.GetGoodsItemInfoByUser(Campus));
    }
}
