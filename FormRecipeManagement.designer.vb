<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRecipeManagement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRecipeManagement))
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.picbx_Icon = New System.Windows.Forms.PictureBox()
        Me.lbl_DateTimeClock = New System.Windows.Forms.Label()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.dsp_Category = New System.Windows.Forms.Label()
        Me.lbl_Category = New System.Windows.Forms.Label()
        Me.lbl_Username = New System.Windows.Forms.Label()
        Me.dsp_Username = New System.Windows.Forms.Label()
        Me.panel_UserCategory = New System.Windows.Forms.Panel()
        Me.lbl_OperationMode = New System.Windows.Forms.Label()
        Me.tabpg_Delete = New System.Windows.Forms.TabPage()
        Me.panel_Delete = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.panel_RecipeDeletion = New System.Windows.Forms.Panel()
        Me.dsp_RecipeDeletion = New System.Windows.Forms.Label()
        Me.cmbx_RcpDeleteRecipeID = New System.Windows.Forms.ComboBox()
        Me.btn_RecipeDelete = New System.Windows.Forms.Button()
        Me.cmbx_RcpDeleteFilterType = New System.Windows.Forms.ComboBox()
        Me.cmbx_RcpDeletePartID = New System.Windows.Forms.ComboBox()
        Me.dsp_RcpDeletePartID = New System.Windows.Forms.Label()
        Me.dsp_RcpDeleteRecipeID = New System.Windows.Forms.Label()
        Me.dsp_RcpDeleteFilterType = New System.Windows.Forms.Label()
        Me.panel_ProdSKUDeletion = New System.Windows.Forms.Panel()
        Me.btn_PartDelete = New System.Windows.Forms.Button()
        Me.dsp_ProdSKUDeletion = New System.Windows.Forms.Label()
        Me.cmbx_PartDeletePartID = New System.Windows.Forms.ComboBox()
        Me.cmbx_PartDeleteFilterType = New System.Windows.Forms.ComboBox()
        Me.dsp_ProdSKUDeletionSKU = New System.Windows.Forms.Label()
        Me.dsp_ProdSKUDeletionPF = New System.Windows.Forms.Label()
        Me.tabctrl_RecipeCtrl = New System.Windows.Forms.TabControl()
        Me.tabpg_RecipeDetails = New System.Windows.Forms.TabPage()
        Me.btn_RcpDetailLoad = New System.Windows.Forms.Button()
        Me.btn_RcpDetailExport = New System.Windows.Forms.Button()
        Me.btn_RcpDetailImport = New System.Windows.Forms.Button()
        Me.btn_RcpDetailEdit = New System.Windows.Forms.Button()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.btn_Reset = New System.Windows.Forms.Button()
        Me.grpbx_Filter = New System.Windows.Forms.GroupBox()
        Me.cmbx_RcpDetailType = New System.Windows.Forms.ComboBox()
        Me.cmbx_RcpDetailPart = New System.Windows.Forms.ComboBox()
        Me.cmbx_RcpDetailFilter = New System.Windows.Forms.ComboBox()
        Me.dsp_FilterProdFamily = New System.Windows.Forms.Label()
        Me.dsp_FilterProdSKU = New System.Windows.Forms.Label()
        Me.dsp_FilterCategory = New System.Windows.Forms.Label()
        Me.grpbx_Search = New System.Windows.Forms.GroupBox()
        Me.cmbx_RcpDetailRecipeIDRev = New System.Windows.Forms.ComboBox()
        Me.cmbx_RcpDetailRecipeID = New System.Windows.Forms.ComboBox()
        Me.dsp_SearchRecipeID = New System.Windows.Forms.Label()
        Me.dgv_RecipeDetails = New System.Windows.Forms.DataGridView()
        Me.tabpg_Edit = New System.Windows.Forms.TabPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dsp_RcpEditPrepPrefillTime = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPrepPrefillStartTime = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditPrepPrefillTime = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpEditPrepPrefillStartTime = New System.Windows.Forms.TextBox()
        Me.dsp_EditPreparation = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPressureDropTime = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPressureDrop = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPrepPressure = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPrepFlow = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPrepBleed = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPrepFill = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditPrepPressureDropTime = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpEditPrepPressureDrop = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpEditPrepPressure = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpEditPrepFlow = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpEditPrepBleed = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpEditPrepFill = New System.Windows.Forms.TextBox()
        Me.panel_RcpEditDrain3 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpEditDrain3Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDrain3Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDrain3Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDrain3Pressure = New System.Windows.Forms.Label()
        Me.checkbx_EditDrain3 = New System.Windows.Forms.CheckBox()
        Me.panel_RcpEditDrain2 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpEditDrain2Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDrain2Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDrain2Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDrain2Pressure = New System.Windows.Forms.Label()
        Me.checkbx_EditDrain2 = New System.Windows.Forms.CheckBox()
        Me.panel_RcpEditFlush2 = New System.Windows.Forms.Panel()
        Me.checkbx_EditFlush2 = New System.Windows.Forms.CheckBox()
        Me.txtbx_RcpEditFlush2Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush2Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush2Stabilize = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush2Stabilize = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush2Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush2Pressure = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush2FlowTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush2FlowTol = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush2Flow = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush2Flow = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpEditVerTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditVerTol = New System.Windows.Forms.Label()
        Me.panel_RcpEditDrain1 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpEditDrain1Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDrain1Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDrain1Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDrain1Pressure = New System.Windows.Forms.Label()
        Me.checkbx_EditDrain1 = New System.Windows.Forms.CheckBox()
        Me.panel_RcpEditDPTest1 = New System.Windows.Forms.Panel()
        Me.checkbx_EditDPTest2 = New System.Windows.Forms.CheckBox()
        Me.checkbx_EditDPTest1 = New System.Windows.Forms.CheckBox()
        Me.txtbx_RcpEditDPPoints = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPPoints = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDPUpLimit = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPUpLimit = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDPLowLimit = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPLowLimit = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDPTime = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPTime = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDPStabilize = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPStabilize = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDPPressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPPressure = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDPFlowTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPFlowTol = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditDPFlow = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditDPFlow = New System.Windows.Forms.Label()
        Me.panel_RcpEditFlush1 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpEditFlush1Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush1Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush1Stabilize = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush1Stabilize = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush1Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush1Pressure = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush1FlowTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpEditFlush1FlowTol = New System.Windows.Forms.Label()
        Me.txtbx_RcpEditFlush1Flow = New System.Windows.Forms.TextBox()
        Me.checkbx_EditFlush1 = New System.Windows.Forms.CheckBox()
        Me.dsp_RcpEditFlush1Flow = New System.Windows.Forms.Label()
        Me.dsp_RcpEditRcpParameters = New System.Windows.Forms.Label()
        Me.panel_Edit = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dsp_RcpDuplication = New System.Windows.Forms.Label()
        Me.btn_RcpDuplicate = New System.Windows.Forms.Button()
        Me.txtbx_RcpDupNewRecipeID = New System.Windows.Forms.TextBox()
        Me.dsp_RcpDupNewRecipeID = New System.Windows.Forms.Label()
        Me.dsp_RcpDupNewType = New System.Windows.Forms.Label()
        Me.dsp_RcpDupSelRecipe = New System.Windows.Forms.Label()
        Me.Cmbx_RcpDupNewType = New System.Windows.Forms.ComboBox()
        Me.cmbx_RcpDupSelRecipe = New System.Windows.Forms.ComboBox()
        Me.btn_EditDiscard = New System.Windows.Forms.Button()
        Me.btn_RcpEditSave = New System.Windows.Forms.Button()
        Me.panel_RecipeManagement = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btn_RcpEdit = New System.Windows.Forms.Button()
        Me.dsp_RcpEditRecipeID = New System.Windows.Forms.Label()
        Me.dsp_RcpEditPartID = New System.Windows.Forms.Label()
        Me.dsp_RcpEditFilterType = New System.Windows.Forms.Label()
        Me.cmbx_RcpEditRecipeID = New System.Windows.Forms.ComboBox()
        Me.cmbx_RcpEditPartID = New System.Windows.Forms.ComboBox()
        Me.cmbx_RcpEditFilterType = New System.Windows.Forms.ComboBox()
        Me.dsp_RcpEditRcpSelection = New System.Windows.Forms.Label()
        Me.tabpg_Create = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dsp_RcpCreatePrepPrefillTime = New System.Windows.Forms.Label()
        Me.dsp_RcpCreatePrepPrefillStartTime = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreatePrepPrefillTime = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpCreatePrepPrefillStartTime = New System.Windows.Forms.TextBox()
        Me.dsp_CreatePreparation = New System.Windows.Forms.Label()
        Me.dsp_RcpCreatePrepPressureDropTime = New System.Windows.Forms.Label()
        Me.dsp_RcpCreatePrepPressureDrop = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dsp_RcpCreatePrepPressure = New System.Windows.Forms.Label()
        Me.dsp_RcpCreatePrepFlow = New System.Windows.Forms.Label()
        Me.dsp_RcpCreatePrepBleed = New System.Windows.Forms.Label()
        Me.dsp_RcpCreatePrepFill = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreatePrepPressureDropTime = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpCreatePrepPressureDrop = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpCreatePrepPressure = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpCreatePrepFlow = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpCreatePrepBleed = New System.Windows.Forms.TextBox()
        Me.txtbx_RcpCreatePrepFill = New System.Windows.Forms.TextBox()
        Me.panel_RcpCreateDrain3 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpCreateDrain3Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDrain3Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDrain3Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDrain3Pressure = New System.Windows.Forms.Label()
        Me.checkbx_CreateDrain3 = New System.Windows.Forms.CheckBox()
        Me.panel_RcpCreateDrain2 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpCreateDrain2Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDrain2Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDrain2Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDrain2Pressure = New System.Windows.Forms.Label()
        Me.checkbx_CreateDrain2 = New System.Windows.Forms.CheckBox()
        Me.panel_RcpCreateFlush2 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpCreateFlush2Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush2Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush2Stabilize = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush2Stabilize = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush2Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush2Pressure = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush2FlowTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush2FlowTol = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush2Flow = New System.Windows.Forms.TextBox()
        Me.checkbx_CreateFlush2 = New System.Windows.Forms.CheckBox()
        Me.dsp_RcpCreateFlush2Flow = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpCreateVerTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateVerTol = New System.Windows.Forms.Label()
        Me.panel_RcpCreateDrain1 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpCreateDrain1Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDrain1Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDrain1Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDrain1Pressure = New System.Windows.Forms.Label()
        Me.checkbx_CreateDrain1 = New System.Windows.Forms.CheckBox()
        Me.panel_RcpCreateDPTest1 = New System.Windows.Forms.Panel()
        Me.checkbx_CreateDPTest2 = New System.Windows.Forms.CheckBox()
        Me.checkbx_CreateDPTest1 = New System.Windows.Forms.CheckBox()
        Me.txtbx_RcpCreateDPPoints = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDPPoints = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDPUpLimit = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDPUpLimit = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDPLowLimit = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDPFlow = New System.Windows.Forms.Label()
        Me.dsp_RcpCreateDPLowLimit = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDPTime = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDPTime = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDPStabilize = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDPStabilize = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDPPressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDPPressure = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDPFlowTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateDPFlowTol = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateDPFlow = New System.Windows.Forms.TextBox()
        Me.panel_RcpCreateFlush1 = New System.Windows.Forms.Panel()
        Me.txtbx_RcpCreateFlush1Time = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush1Time = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush1Stabilize = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush1Stabilize = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush1Pressure = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush1Pressure = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush1FlowTol = New System.Windows.Forms.TextBox()
        Me.dsp_RcpCreateFlush1FlowTol = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateFlush1Flow = New System.Windows.Forms.TextBox()
        Me.checkbx_CreateFlush1 = New System.Windows.Forms.CheckBox()
        Me.dsp_RcpCreateFlush1Flow = New System.Windows.Forms.Label()
        Me.dsp_RcpCreateRcpParameters = New System.Windows.Forms.Label()
        Me.panel_Create = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.panel_RecipeGeneration = New System.Windows.Forms.Panel()
        Me.dsp_RcpCreation = New System.Windows.Forms.Label()
        Me.txtbx_RcpCreateRecipeID = New System.Windows.Forms.TextBox()
        Me.cmbx_RcpCreateType = New System.Windows.Forms.ComboBox()
        Me.btn_RecipeIDCreate = New System.Windows.Forms.Button()
        Me.cmbx_RcpCreateFilterType = New System.Windows.Forms.ComboBox()
        Me.dsp_RcpCreateType = New System.Windows.Forms.Label()
        Me.cmbx_RcpCreatePartID = New System.Windows.Forms.ComboBox()
        Me.dsp_RcpCreatePart = New System.Windows.Forms.Label()
        Me.dsp_RcpCreateRecipeID = New System.Windows.Forms.Label()
        Me.dsp_RcpCreateFilter = New System.Windows.Forms.Label()
        Me.panel_ProdSKUCreation = New System.Windows.Forms.Panel()
        Me.cmbx_PartCreateJigType = New System.Windows.Forms.ComboBox()
        Me.txtbx_PartCreatePartID = New System.Windows.Forms.TextBox()
        Me.btnPartIDCreate = New System.Windows.Forms.Button()
        Me.dsp_PartIDCreation = New System.Windows.Forms.Label()
        Me.cmbx_PartCreateFilterType = New System.Windows.Forms.ComboBox()
        Me.dsp_PartCreatePartID = New System.Windows.Forms.Label()
        Me.dsp_PartCreateFiltertype = New System.Windows.Forms.Label()
        Me.dsp_PartCreateJigType = New System.Windows.Forms.Label()
        Me.panel_FormControl = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dsp_Home = New System.Windows.Forms.Label()
        Me.btn_Home = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_UserCategory.SuspendLayout()
        Me.tabpg_Delete.SuspendLayout()
        Me.panel_Delete.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.panel_RecipeDeletion.SuspendLayout()
        Me.panel_ProdSKUDeletion.SuspendLayout()
        Me.tabctrl_RecipeCtrl.SuspendLayout()
        Me.tabpg_RecipeDetails.SuspendLayout()
        Me.grpbx_Filter.SuspendLayout()
        Me.grpbx_Search.SuspendLayout()
        CType(Me.dgv_RecipeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpg_Edit.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panel_RcpEditDrain3.SuspendLayout()
        Me.panel_RcpEditDrain2.SuspendLayout()
        Me.panel_RcpEditFlush2.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.panel_RcpEditDrain1.SuspendLayout()
        Me.panel_RcpEditDPTest1.SuspendLayout()
        Me.panel_RcpEditFlush1.SuspendLayout()
        Me.panel_Edit.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panel_RecipeManagement.SuspendLayout()
        Me.tabpg_Create.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.panel_RcpCreateDrain3.SuspendLayout()
        Me.panel_RcpCreateDrain2.SuspendLayout()
        Me.panel_RcpCreateFlush2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.panel_RcpCreateDrain1.SuspendLayout()
        Me.panel_RcpCreateDPTest1.SuspendLayout()
        Me.panel_RcpCreateFlush1.SuspendLayout()
        Me.panel_Create.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.panel_RecipeGeneration.SuspendLayout()
        Me.panel_ProdSKUCreation.SuspendLayout()
        Me.panel_FormControl.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Version
        '
        Me.lbl_Version.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Version.Location = New System.Drawing.Point(1782, 160)
        Me.lbl_Version.Name = "lbl_Version"
        Me.lbl_Version.Size = New System.Drawing.Size(120, 18)
        Me.lbl_Version.TabIndex = 38
        Me.lbl_Version.Text = "Ver. 0.0"
        Me.lbl_Version.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picbx_Icon
        '
        Me.picbx_Icon.Image = CType(resources.GetObject("picbx_Icon.Image"), System.Drawing.Image)
        Me.picbx_Icon.Location = New System.Drawing.Point(1792, 57)
        Me.picbx_Icon.Name = "picbx_Icon"
        Me.picbx_Icon.Size = New System.Drawing.Size(100, 100)
        Me.picbx_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picbx_Icon.TabIndex = 37
        Me.picbx_Icon.TabStop = False
        '
        'lbl_DateTimeClock
        '
        Me.lbl_DateTimeClock.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DateTimeClock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.lbl_DateTimeClock.Location = New System.Drawing.Point(10, 42)
        Me.lbl_DateTimeClock.Name = "lbl_DateTimeClock"
        Me.lbl_DateTimeClock.Size = New System.Drawing.Size(250, 50)
        Me.lbl_DateTimeClock.TabIndex = 36
        Me.lbl_DateTimeClock.Text = "2023-01-01 23:59:59"
        Me.lbl_DateTimeClock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Title
        '
        Me.lbl_Title.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_Title.Font = New System.Drawing.Font("Segoe UI Semibold", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Title.Location = New System.Drawing.Point(0, 40)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(1904, 50)
        Me.lbl_Title.TabIndex = 0
        Me.lbl_Title.Text = "DP Tester"
        Me.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsp_Category
        '
        Me.dsp_Category.AutoSize = True
        Me.dsp_Category.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Category.Location = New System.Drawing.Point(40, 25)
        Me.dsp_Category.Name = "dsp_Category"
        Me.dsp_Category.Size = New System.Drawing.Size(68, 17)
        Me.dsp_Category.TabIndex = 8
        Me.dsp_Category.Text = "Category :"
        '
        'lbl_Category
        '
        Me.lbl_Category.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Category.Location = New System.Drawing.Point(114, 25)
        Me.lbl_Category.Name = "lbl_Category"
        Me.lbl_Category.Size = New System.Drawing.Size(250, 17)
        Me.lbl_Category.TabIndex = 8
        Me.lbl_Category.Text = "-"
        '
        'lbl_Username
        '
        Me.lbl_Username.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Username.Location = New System.Drawing.Point(114, 3)
        Me.lbl_Username.Name = "lbl_Username"
        Me.lbl_Username.Size = New System.Drawing.Size(250, 17)
        Me.lbl_Username.TabIndex = 8
        Me.lbl_Username.Text = "-"
        '
        'dsp_Username
        '
        Me.dsp_Username.AutoSize = True
        Me.dsp_Username.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Username.Location = New System.Drawing.Point(34, 3)
        Me.dsp_Username.Name = "dsp_Username"
        Me.dsp_Username.Size = New System.Drawing.Size(74, 17)
        Me.dsp_Username.TabIndex = 8
        Me.dsp_Username.Text = "Username :"
        '
        'panel_UserCategory
        '
        Me.panel_UserCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_UserCategory.Controls.Add(Me.dsp_Category)
        Me.panel_UserCategory.Controls.Add(Me.lbl_Category)
        Me.panel_UserCategory.Controls.Add(Me.lbl_Username)
        Me.panel_UserCategory.Controls.Add(Me.dsp_Username)
        Me.panel_UserCategory.Location = New System.Drawing.Point(12, 93)
        Me.panel_UserCategory.Name = "panel_UserCategory"
        Me.panel_UserCategory.Size = New System.Drawing.Size(400, 50)
        Me.panel_UserCategory.TabIndex = 48
        '
        'lbl_OperationMode
        '
        Me.lbl_OperationMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_OperationMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_OperationMode.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_OperationMode.ForeColor = System.Drawing.SystemColors.Window
        Me.lbl_OperationMode.Location = New System.Drawing.Point(0, 0)
        Me.lbl_OperationMode.Name = "lbl_OperationMode"
        Me.lbl_OperationMode.Size = New System.Drawing.Size(1904, 40)
        Me.lbl_OperationMode.TabIndex = 34
        Me.lbl_OperationMode.Text = "Auto Mode"
        Me.lbl_OperationMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabpg_Delete
        '
        Me.tabpg_Delete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabpg_Delete.Controls.Add(Me.panel_Delete)
        Me.tabpg_Delete.Location = New System.Drawing.Point(4, 44)
        Me.tabpg_Delete.Name = "tabpg_Delete"
        Me.tabpg_Delete.Size = New System.Drawing.Size(1872, 769)
        Me.tabpg_Delete.TabIndex = 2
        Me.tabpg_Delete.Text = "Delete"
        Me.tabpg_Delete.UseVisualStyleBackColor = True
        '
        'panel_Delete
        '
        Me.panel_Delete.Controls.Add(Me.Panel5)
        Me.panel_Delete.Controls.Add(Me.panel_RecipeDeletion)
        Me.panel_Delete.Controls.Add(Me.panel_ProdSKUDeletion)
        Me.panel_Delete.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel_Delete.Location = New System.Drawing.Point(0, 0)
        Me.panel_Delete.Name = "panel_Delete"
        Me.panel_Delete.Size = New System.Drawing.Size(562, 767)
        Me.panel_Delete.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.ComboBox2)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.ComboBox1)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Location = New System.Drawing.Point(3, 488)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(556, 200)
        Me.Panel5.TabIndex = 4
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Fittings", "Blank"})
        Me.ComboBox2.Location = New System.Drawing.Point(152, 113)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(250, 29)
        Me.ComboBox2.TabIndex = 106
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(420, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 60)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Delete"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(554, 50)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Fitting Type Deletion"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox1.Location = New System.Drawing.Point(152, 68)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(250, 29)
        Me.ComboBox1.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 25)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "ID :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 25)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Fitting Type :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_RecipeDeletion
        '
        Me.panel_RecipeDeletion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RecipeDeletion.Controls.Add(Me.dsp_RecipeDeletion)
        Me.panel_RecipeDeletion.Controls.Add(Me.cmbx_RcpDeleteRecipeID)
        Me.panel_RecipeDeletion.Controls.Add(Me.btn_RecipeDelete)
        Me.panel_RecipeDeletion.Controls.Add(Me.cmbx_RcpDeleteFilterType)
        Me.panel_RecipeDeletion.Controls.Add(Me.cmbx_RcpDeletePartID)
        Me.panel_RecipeDeletion.Controls.Add(Me.dsp_RcpDeletePartID)
        Me.panel_RecipeDeletion.Controls.Add(Me.dsp_RcpDeleteRecipeID)
        Me.panel_RecipeDeletion.Controls.Add(Me.dsp_RcpDeleteFilterType)
        Me.panel_RecipeDeletion.Location = New System.Drawing.Point(3, 227)
        Me.panel_RecipeDeletion.Name = "panel_RecipeDeletion"
        Me.panel_RecipeDeletion.Size = New System.Drawing.Size(556, 257)
        Me.panel_RecipeDeletion.TabIndex = 3
        '
        'dsp_RecipeDeletion
        '
        Me.dsp_RecipeDeletion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dsp_RecipeDeletion.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RecipeDeletion.Location = New System.Drawing.Point(0, 0)
        Me.dsp_RecipeDeletion.Name = "dsp_RecipeDeletion"
        Me.dsp_RecipeDeletion.Size = New System.Drawing.Size(554, 50)
        Me.dsp_RecipeDeletion.TabIndex = 103
        Me.dsp_RecipeDeletion.Text = "Recipe ID Deletion"
        Me.dsp_RecipeDeletion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbx_RcpDeleteRecipeID
        '
        Me.cmbx_RcpDeleteRecipeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDeleteRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDeleteRecipeID.FormattingEnabled = True
        Me.cmbx_RcpDeleteRecipeID.Location = New System.Drawing.Point(152, 159)
        Me.cmbx_RcpDeleteRecipeID.Name = "cmbx_RcpDeleteRecipeID"
        Me.cmbx_RcpDeleteRecipeID.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpDeleteRecipeID.TabIndex = 19
        '
        'btn_RecipeDelete
        '
        Me.btn_RecipeDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_RecipeDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_RecipeDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecipeDelete.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_RecipeDelete.Location = New System.Drawing.Point(420, 118)
        Me.btn_RecipeDelete.Name = "btn_RecipeDelete"
        Me.btn_RecipeDelete.Size = New System.Drawing.Size(110, 60)
        Me.btn_RecipeDelete.TabIndex = 20
        Me.btn_RecipeDelete.Text = "Delete"
        Me.btn_RecipeDelete.UseVisualStyleBackColor = False
        '
        'cmbx_RcpDeleteFilterType
        '
        Me.cmbx_RcpDeleteFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDeleteFilterType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDeleteFilterType.FormattingEnabled = True
        Me.cmbx_RcpDeleteFilterType.Location = New System.Drawing.Point(152, 69)
        Me.cmbx_RcpDeleteFilterType.Name = "cmbx_RcpDeleteFilterType"
        Me.cmbx_RcpDeleteFilterType.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpDeleteFilterType.TabIndex = 16
        '
        'cmbx_RcpDeletePartID
        '
        Me.cmbx_RcpDeletePartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDeletePartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDeletePartID.FormattingEnabled = True
        Me.cmbx_RcpDeletePartID.Location = New System.Drawing.Point(152, 114)
        Me.cmbx_RcpDeletePartID.Name = "cmbx_RcpDeletePartID"
        Me.cmbx_RcpDeletePartID.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpDeletePartID.TabIndex = 17
        '
        'dsp_RcpDeletePartID
        '
        Me.dsp_RcpDeletePartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpDeletePartID.Location = New System.Drawing.Point(21, 115)
        Me.dsp_RcpDeletePartID.Name = "dsp_RcpDeletePartID"
        Me.dsp_RcpDeletePartID.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpDeletePartID.TabIndex = 104
        Me.dsp_RcpDeletePartID.Text = "Part ID :"
        Me.dsp_RcpDeletePartID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpDeleteRecipeID
        '
        Me.dsp_RcpDeleteRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpDeleteRecipeID.Location = New System.Drawing.Point(21, 160)
        Me.dsp_RcpDeleteRecipeID.Name = "dsp_RcpDeleteRecipeID"
        Me.dsp_RcpDeleteRecipeID.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpDeleteRecipeID.TabIndex = 104
        Me.dsp_RcpDeleteRecipeID.Text = "Recipe ID :"
        Me.dsp_RcpDeleteRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpDeleteFilterType
        '
        Me.dsp_RcpDeleteFilterType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpDeleteFilterType.Location = New System.Drawing.Point(21, 69)
        Me.dsp_RcpDeleteFilterType.Name = "dsp_RcpDeleteFilterType"
        Me.dsp_RcpDeleteFilterType.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpDeleteFilterType.TabIndex = 104
        Me.dsp_RcpDeleteFilterType.Text = "Filter Type :"
        Me.dsp_RcpDeleteFilterType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_ProdSKUDeletion
        '
        Me.panel_ProdSKUDeletion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_ProdSKUDeletion.Controls.Add(Me.btn_PartDelete)
        Me.panel_ProdSKUDeletion.Controls.Add(Me.dsp_ProdSKUDeletion)
        Me.panel_ProdSKUDeletion.Controls.Add(Me.cmbx_PartDeletePartID)
        Me.panel_ProdSKUDeletion.Controls.Add(Me.cmbx_PartDeleteFilterType)
        Me.panel_ProdSKUDeletion.Controls.Add(Me.dsp_ProdSKUDeletionSKU)
        Me.panel_ProdSKUDeletion.Controls.Add(Me.dsp_ProdSKUDeletionPF)
        Me.panel_ProdSKUDeletion.Location = New System.Drawing.Point(3, 3)
        Me.panel_ProdSKUDeletion.Name = "panel_ProdSKUDeletion"
        Me.panel_ProdSKUDeletion.Size = New System.Drawing.Size(556, 220)
        Me.panel_ProdSKUDeletion.TabIndex = 2
        '
        'btn_PartDelete
        '
        Me.btn_PartDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_PartDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_PartDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_PartDelete.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_PartDelete.Location = New System.Drawing.Point(420, 106)
        Me.btn_PartDelete.Name = "btn_PartDelete"
        Me.btn_PartDelete.Size = New System.Drawing.Size(110, 60)
        Me.btn_PartDelete.TabIndex = 15
        Me.btn_PartDelete.Text = "Delete"
        Me.btn_PartDelete.UseVisualStyleBackColor = False
        '
        'dsp_ProdSKUDeletion
        '
        Me.dsp_ProdSKUDeletion.Dock = System.Windows.Forms.DockStyle.Top
        Me.dsp_ProdSKUDeletion.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ProdSKUDeletion.Location = New System.Drawing.Point(0, 0)
        Me.dsp_ProdSKUDeletion.Name = "dsp_ProdSKUDeletion"
        Me.dsp_ProdSKUDeletion.Size = New System.Drawing.Size(554, 50)
        Me.dsp_ProdSKUDeletion.TabIndex = 103
        Me.dsp_ProdSKUDeletion.Text = "Part ID Deletion"
        Me.dsp_ProdSKUDeletion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbx_PartDeletePartID
        '
        Me.cmbx_PartDeletePartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_PartDeletePartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_PartDeletePartID.FormattingEnabled = True
        Me.cmbx_PartDeletePartID.Location = New System.Drawing.Point(152, 113)
        Me.cmbx_PartDeletePartID.Name = "cmbx_PartDeletePartID"
        Me.cmbx_PartDeletePartID.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_PartDeletePartID.TabIndex = 14
        '
        'cmbx_PartDeleteFilterType
        '
        Me.cmbx_PartDeleteFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_PartDeleteFilterType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_PartDeleteFilterType.FormattingEnabled = True
        Me.cmbx_PartDeleteFilterType.Location = New System.Drawing.Point(152, 68)
        Me.cmbx_PartDeleteFilterType.Name = "cmbx_PartDeleteFilterType"
        Me.cmbx_PartDeleteFilterType.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_PartDeleteFilterType.TabIndex = 13
        '
        'dsp_ProdSKUDeletionSKU
        '
        Me.dsp_ProdSKUDeletionSKU.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ProdSKUDeletionSKU.Location = New System.Drawing.Point(21, 114)
        Me.dsp_ProdSKUDeletionSKU.Name = "dsp_ProdSKUDeletionSKU"
        Me.dsp_ProdSKUDeletionSKU.Size = New System.Drawing.Size(125, 25)
        Me.dsp_ProdSKUDeletionSKU.TabIndex = 104
        Me.dsp_ProdSKUDeletionSKU.Text = "Part ID :"
        Me.dsp_ProdSKUDeletionSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_ProdSKUDeletionPF
        '
        Me.dsp_ProdSKUDeletionPF.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_ProdSKUDeletionPF.Location = New System.Drawing.Point(21, 69)
        Me.dsp_ProdSKUDeletionPF.Name = "dsp_ProdSKUDeletionPF"
        Me.dsp_ProdSKUDeletionPF.Size = New System.Drawing.Size(125, 25)
        Me.dsp_ProdSKUDeletionPF.TabIndex = 104
        Me.dsp_ProdSKUDeletionPF.Text = "Filter Type :"
        Me.dsp_ProdSKUDeletionPF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabctrl_RecipeCtrl
        '
        Me.tabctrl_RecipeCtrl.Controls.Add(Me.tabpg_RecipeDetails)
        Me.tabctrl_RecipeCtrl.Controls.Add(Me.tabpg_Edit)
        Me.tabctrl_RecipeCtrl.Controls.Add(Me.tabpg_Create)
        Me.tabctrl_RecipeCtrl.Controls.Add(Me.tabpg_Delete)
        Me.tabctrl_RecipeCtrl.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabctrl_RecipeCtrl.ItemSize = New System.Drawing.Size(150, 40)
        Me.tabctrl_RecipeCtrl.Location = New System.Drawing.Point(12, 181)
        Me.tabctrl_RecipeCtrl.Multiline = True
        Me.tabctrl_RecipeCtrl.Name = "tabctrl_RecipeCtrl"
        Me.tabctrl_RecipeCtrl.SelectedIndex = 0
        Me.tabctrl_RecipeCtrl.Size = New System.Drawing.Size(1880, 817)
        Me.tabctrl_RecipeCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabctrl_RecipeCtrl.TabIndex = 1
        Me.tabctrl_RecipeCtrl.TabStop = False
        '
        'tabpg_RecipeDetails
        '
        Me.tabpg_RecipeDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabpg_RecipeDetails.Controls.Add(Me.btn_RcpDetailLoad)
        Me.tabpg_RecipeDetails.Controls.Add(Me.btn_RcpDetailExport)
        Me.tabpg_RecipeDetails.Controls.Add(Me.btn_RcpDetailImport)
        Me.tabpg_RecipeDetails.Controls.Add(Me.btn_RcpDetailEdit)
        Me.tabpg_RecipeDetails.Controls.Add(Me.btn_Search)
        Me.tabpg_RecipeDetails.Controls.Add(Me.btn_Reset)
        Me.tabpg_RecipeDetails.Controls.Add(Me.grpbx_Filter)
        Me.tabpg_RecipeDetails.Controls.Add(Me.grpbx_Search)
        Me.tabpg_RecipeDetails.Controls.Add(Me.dgv_RecipeDetails)
        Me.tabpg_RecipeDetails.Location = New System.Drawing.Point(4, 44)
        Me.tabpg_RecipeDetails.Name = "tabpg_RecipeDetails"
        Me.tabpg_RecipeDetails.Size = New System.Drawing.Size(1872, 769)
        Me.tabpg_RecipeDetails.TabIndex = 3
        Me.tabpg_RecipeDetails.Text = "Recipe Details"
        Me.tabpg_RecipeDetails.UseVisualStyleBackColor = True
        '
        'btn_RcpDetailLoad
        '
        Me.btn_RcpDetailLoad.Location = New System.Drawing.Point(1531, 27)
        Me.btn_RcpDetailLoad.Name = "btn_RcpDetailLoad"
        Me.btn_RcpDetailLoad.Size = New System.Drawing.Size(100, 45)
        Me.btn_RcpDetailLoad.TabIndex = 32
        Me.btn_RcpDetailLoad.Text = "Load"
        Me.btn_RcpDetailLoad.UseVisualStyleBackColor = True
        Me.btn_RcpDetailLoad.Visible = False
        '
        'btn_RcpDetailExport
        '
        Me.btn_RcpDetailExport.Location = New System.Drawing.Point(1743, 27)
        Me.btn_RcpDetailExport.Name = "btn_RcpDetailExport"
        Me.btn_RcpDetailExport.Size = New System.Drawing.Size(100, 45)
        Me.btn_RcpDetailExport.TabIndex = 19
        Me.btn_RcpDetailExport.Text = "Export"
        Me.btn_RcpDetailExport.UseVisualStyleBackColor = True
        '
        'btn_RcpDetailImport
        '
        Me.btn_RcpDetailImport.Location = New System.Drawing.Point(1425, 27)
        Me.btn_RcpDetailImport.Name = "btn_RcpDetailImport"
        Me.btn_RcpDetailImport.Size = New System.Drawing.Size(100, 45)
        Me.btn_RcpDetailImport.TabIndex = 18
        Me.btn_RcpDetailImport.Text = "Import"
        Me.btn_RcpDetailImport.UseVisualStyleBackColor = True
        Me.btn_RcpDetailImport.Visible = False
        '
        'btn_RcpDetailEdit
        '
        Me.btn_RcpDetailEdit.Location = New System.Drawing.Point(1637, 27)
        Me.btn_RcpDetailEdit.Name = "btn_RcpDetailEdit"
        Me.btn_RcpDetailEdit.Size = New System.Drawing.Size(100, 45)
        Me.btn_RcpDetailEdit.TabIndex = 17
        Me.btn_RcpDetailEdit.Text = "Edit"
        Me.btn_RcpDetailEdit.UseVisualStyleBackColor = True
        '
        'btn_Search
        '
        Me.btn_Search.Location = New System.Drawing.Point(1014, 27)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(100, 45)
        Me.btn_Search.TabIndex = 15
        Me.btn_Search.Text = "Search"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'btn_Reset
        '
        Me.btn_Reset.Location = New System.Drawing.Point(1120, 27)
        Me.btn_Reset.Name = "btn_Reset"
        Me.btn_Reset.Size = New System.Drawing.Size(100, 45)
        Me.btn_Reset.TabIndex = 16
        Me.btn_Reset.Text = "Reset"
        Me.btn_Reset.UseVisualStyleBackColor = True
        '
        'grpbx_Filter
        '
        Me.grpbx_Filter.Controls.Add(Me.cmbx_RcpDetailType)
        Me.grpbx_Filter.Controls.Add(Me.cmbx_RcpDetailPart)
        Me.grpbx_Filter.Controls.Add(Me.cmbx_RcpDetailFilter)
        Me.grpbx_Filter.Controls.Add(Me.dsp_FilterProdFamily)
        Me.grpbx_Filter.Controls.Add(Me.dsp_FilterProdSKU)
        Me.grpbx_Filter.Controls.Add(Me.dsp_FilterCategory)
        Me.grpbx_Filter.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpbx_Filter.Location = New System.Drawing.Point(348, 6)
        Me.grpbx_Filter.Name = "grpbx_Filter"
        Me.grpbx_Filter.Size = New System.Drawing.Size(640, 80)
        Me.grpbx_Filter.TabIndex = 2
        Me.grpbx_Filter.TabStop = False
        Me.grpbx_Filter.Text = "Filter"
        '
        'cmbx_RcpDetailType
        '
        Me.cmbx_RcpDetailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDetailType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDetailType.FormattingEnabled = True
        Me.cmbx_RcpDetailType.Location = New System.Drawing.Point(427, 41)
        Me.cmbx_RcpDetailType.Name = "cmbx_RcpDetailType"
        Me.cmbx_RcpDetailType.Size = New System.Drawing.Size(200, 25)
        Me.cmbx_RcpDetailType.TabIndex = 14
        '
        'cmbx_RcpDetailPart
        '
        Me.cmbx_RcpDetailPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDetailPart.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDetailPart.FormattingEnabled = True
        Me.cmbx_RcpDetailPart.Location = New System.Drawing.Point(221, 41)
        Me.cmbx_RcpDetailPart.Name = "cmbx_RcpDetailPart"
        Me.cmbx_RcpDetailPart.Size = New System.Drawing.Size(200, 25)
        Me.cmbx_RcpDetailPart.TabIndex = 13
        '
        'cmbx_RcpDetailFilter
        '
        Me.cmbx_RcpDetailFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDetailFilter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDetailFilter.FormattingEnabled = True
        Me.cmbx_RcpDetailFilter.Location = New System.Drawing.Point(15, 41)
        Me.cmbx_RcpDetailFilter.Name = "cmbx_RcpDetailFilter"
        Me.cmbx_RcpDetailFilter.Size = New System.Drawing.Size(200, 25)
        Me.cmbx_RcpDetailFilter.TabIndex = 12
        '
        'dsp_FilterProdFamily
        '
        Me.dsp_FilterProdFamily.AutoSize = True
        Me.dsp_FilterProdFamily.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_FilterProdFamily.Location = New System.Drawing.Point(12, 21)
        Me.dsp_FilterProdFamily.Name = "dsp_FilterProdFamily"
        Me.dsp_FilterProdFamily.Size = New System.Drawing.Size(74, 17)
        Me.dsp_FilterProdFamily.TabIndex = 9
        Me.dsp_FilterProdFamily.Text = "Filter Type :"
        '
        'dsp_FilterProdSKU
        '
        Me.dsp_FilterProdSKU.AutoSize = True
        Me.dsp_FilterProdSKU.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_FilterProdSKU.Location = New System.Drawing.Point(218, 21)
        Me.dsp_FilterProdSKU.Name = "dsp_FilterProdSKU"
        Me.dsp_FilterProdSKU.Size = New System.Drawing.Size(54, 17)
        Me.dsp_FilterProdSKU.TabIndex = 9
        Me.dsp_FilterProdSKU.Text = "Part ID :"
        '
        'dsp_FilterCategory
        '
        Me.dsp_FilterCategory.AutoSize = True
        Me.dsp_FilterCategory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_FilterCategory.Location = New System.Drawing.Point(424, 21)
        Me.dsp_FilterCategory.Name = "dsp_FilterCategory"
        Me.dsp_FilterCategory.Size = New System.Drawing.Size(85, 17)
        Me.dsp_FilterCategory.TabIndex = 9
        Me.dsp_FilterCategory.Text = "Recipe Type :"
        '
        'grpbx_Search
        '
        Me.grpbx_Search.Controls.Add(Me.cmbx_RcpDetailRecipeIDRev)
        Me.grpbx_Search.Controls.Add(Me.cmbx_RcpDetailRecipeID)
        Me.grpbx_Search.Controls.Add(Me.dsp_SearchRecipeID)
        Me.grpbx_Search.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpbx_Search.Location = New System.Drawing.Point(3, 6)
        Me.grpbx_Search.Name = "grpbx_Search"
        Me.grpbx_Search.Size = New System.Drawing.Size(330, 80)
        Me.grpbx_Search.TabIndex = 1
        Me.grpbx_Search.TabStop = False
        Me.grpbx_Search.Text = "Search"
        '
        'cmbx_RcpDetailRecipeIDRev
        '
        Me.cmbx_RcpDetailRecipeIDRev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDetailRecipeIDRev.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDetailRecipeIDRev.FormattingEnabled = True
        Me.cmbx_RcpDetailRecipeIDRev.Location = New System.Drawing.Point(225, 41)
        Me.cmbx_RcpDetailRecipeIDRev.Name = "cmbx_RcpDetailRecipeIDRev"
        Me.cmbx_RcpDetailRecipeIDRev.Size = New System.Drawing.Size(90, 25)
        Me.cmbx_RcpDetailRecipeIDRev.TabIndex = 10
        '
        'cmbx_RcpDetailRecipeID
        '
        Me.cmbx_RcpDetailRecipeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDetailRecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDetailRecipeID.FormattingEnabled = True
        Me.cmbx_RcpDetailRecipeID.Location = New System.Drawing.Point(15, 41)
        Me.cmbx_RcpDetailRecipeID.Name = "cmbx_RcpDetailRecipeID"
        Me.cmbx_RcpDetailRecipeID.Size = New System.Drawing.Size(204, 25)
        Me.cmbx_RcpDetailRecipeID.TabIndex = 10
        '
        'dsp_SearchRecipeID
        '
        Me.dsp_SearchRecipeID.AutoSize = True
        Me.dsp_SearchRecipeID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_SearchRecipeID.Location = New System.Drawing.Point(12, 21)
        Me.dsp_SearchRecipeID.Name = "dsp_SearchRecipeID"
        Me.dsp_SearchRecipeID.Size = New System.Drawing.Size(70, 17)
        Me.dsp_SearchRecipeID.TabIndex = 9
        Me.dsp_SearchRecipeID.Text = "Recipe ID :"
        '
        'dgv_RecipeDetails
        '
        Me.dgv_RecipeDetails.AllowUserToAddRows = False
        Me.dgv_RecipeDetails.AllowUserToDeleteRows = False
        Me.dgv_RecipeDetails.AllowUserToResizeRows = False
        Me.dgv_RecipeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_RecipeDetails.Location = New System.Drawing.Point(3, 92)
        Me.dgv_RecipeDetails.MultiSelect = False
        Me.dgv_RecipeDetails.Name = "dgv_RecipeDetails"
        Me.dgv_RecipeDetails.ReadOnly = True
        Me.dgv_RecipeDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_RecipeDetails.Size = New System.Drawing.Size(1865, 671)
        Me.dgv_RecipeDetails.TabIndex = 31
        Me.dgv_RecipeDetails.TabStop = False
        '
        'tabpg_Edit
        '
        Me.tabpg_Edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabpg_Edit.Controls.Add(Me.Panel7)
        Me.tabpg_Edit.Controls.Add(Me.Panel2)
        Me.tabpg_Edit.Controls.Add(Me.panel_RcpEditDrain3)
        Me.tabpg_Edit.Controls.Add(Me.panel_RcpEditDrain2)
        Me.tabpg_Edit.Controls.Add(Me.panel_RcpEditFlush2)
        Me.tabpg_Edit.Controls.Add(Me.Panel18)
        Me.tabpg_Edit.Controls.Add(Me.panel_RcpEditDrain1)
        Me.tabpg_Edit.Controls.Add(Me.panel_RcpEditDPTest1)
        Me.tabpg_Edit.Controls.Add(Me.panel_RcpEditFlush1)
        Me.tabpg_Edit.Controls.Add(Me.dsp_RcpEditRcpParameters)
        Me.tabpg_Edit.Controls.Add(Me.panel_Edit)
        Me.tabpg_Edit.Location = New System.Drawing.Point(4, 44)
        Me.tabpg_Edit.Name = "tabpg_Edit"
        Me.tabpg_Edit.Size = New System.Drawing.Size(1872, 769)
        Me.tabpg_Edit.TabIndex = 4
        Me.tabpg_Edit.Text = "Edit"
        Me.tabpg_Edit.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label14)
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.Label18)
        Me.Panel7.Controls.Add(Me.ComboBox7)
        Me.Panel7.Controls.Add(Me.ComboBox8)
        Me.Panel7.Controls.Add(Me.ComboBox9)
        Me.Panel7.Location = New System.Drawing.Point(575, 591)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(307, 170)
        Me.Panel7.TabIndex = 37
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(49, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(200, 40)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Fitting Type"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(42, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 17)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Blank :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(37, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 17)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Outlet :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(48, 60)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 17)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Inlet :"
        '
        'ComboBox7
        '
        Me.ComboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox7.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox7.Location = New System.Drawing.Point(93, 127)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(170, 25)
        Me.ComboBox7.TabIndex = 14
        '
        'ComboBox8
        '
        Me.ComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox8.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox8.Location = New System.Drawing.Point(93, 92)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(170, 25)
        Me.ComboBox8.TabIndex = 14
        '
        'ComboBox9
        '
        Me.ComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox9.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox9.Location = New System.Drawing.Point(93, 57)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(170, 25)
        Me.ComboBox9.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPrepPrefillTime)
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPrepPrefillStartTime)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepPrefillTime)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepPrefillStartTime)
        Me.Panel2.Controls.Add(Me.dsp_EditPreparation)
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPressureDropTime)
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPressureDrop)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPrepPressure)
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPrepFlow)
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPrepBleed)
        Me.Panel2.Controls.Add(Me.dsp_RcpEditPrepFill)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepPressureDropTime)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepPressureDrop)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepPressure)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepFlow)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepBleed)
        Me.Panel2.Controls.Add(Me.txtbx_RcpEditPrepFill)
        Me.Panel2.Location = New System.Drawing.Point(575, 135)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(307, 450)
        Me.Panel2.TabIndex = 34
        '
        'dsp_RcpEditPrepPrefillTime
        '
        Me.dsp_RcpEditPrepPrefillTime.Location = New System.Drawing.Point(17, 394)
        Me.dsp_RcpEditPrepPrefillTime.Name = "dsp_RcpEditPrepPrefillTime"
        Me.dsp_RcpEditPrepPrefillTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPrepPrefillTime.TabIndex = 34
        Me.dsp_RcpEditPrepPrefillTime.Text = "Prep Prefill Vent" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Duration (s) :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.dsp_RcpEditPrepPrefillTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditPrepPrefillStartTime
        '
        Me.dsp_RcpEditPrepPrefillStartTime.Location = New System.Drawing.Point(17, 346)
        Me.dsp_RcpEditPrepPrefillStartTime.Name = "dsp_RcpEditPrepPrefillStartTime"
        Me.dsp_RcpEditPrepPrefillStartTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPrepPrefillStartTime.TabIndex = 35
        Me.dsp_RcpEditPrepPrefillStartTime.Text = "Prep Prefill Vent" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Start Time (s) :"
        Me.dsp_RcpEditPrepPrefillStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditPrepPrefillTime
        '
        Me.txtbx_RcpEditPrepPrefillTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepPrefillTime.Location = New System.Drawing.Point(183, 402)
        Me.txtbx_RcpEditPrepPrefillTime.MaxLength = 3
        Me.txtbx_RcpEditPrepPrefillTime.Name = "txtbx_RcpEditPrepPrefillTime"
        Me.txtbx_RcpEditPrepPrefillTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepPrefillTime.TabIndex = 37
        '
        'txtbx_RcpEditPrepPrefillStartTime
        '
        Me.txtbx_RcpEditPrepPrefillStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepPrefillStartTime.Location = New System.Drawing.Point(183, 354)
        Me.txtbx_RcpEditPrepPrefillStartTime.MaxLength = 3
        Me.txtbx_RcpEditPrepPrefillStartTime.Name = "txtbx_RcpEditPrepPrefillStartTime"
        Me.txtbx_RcpEditPrepPrefillStartTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepPrefillStartTime.TabIndex = 38
        '
        'dsp_EditPreparation
        '
        Me.dsp_EditPreparation.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.dsp_EditPreparation.Location = New System.Drawing.Point(49, 15)
        Me.dsp_EditPreparation.Name = "dsp_EditPreparation"
        Me.dsp_EditPreparation.Size = New System.Drawing.Size(200, 40)
        Me.dsp_EditPreparation.TabIndex = 33
        Me.dsp_EditPreparation.Text = "Preparation"
        Me.dsp_EditPreparation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsp_RcpEditPressureDropTime
        '
        Me.dsp_RcpEditPressureDropTime.Location = New System.Drawing.Point(17, 298)
        Me.dsp_RcpEditPressureDropTime.Name = "dsp_RcpEditPressureDropTime"
        Me.dsp_RcpEditPressureDropTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPressureDropTime.TabIndex = 25
        Me.dsp_RcpEditPressureDropTime.Text = "Back Pressure-2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Time (s) :"
        Me.dsp_RcpEditPressureDropTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditPressureDrop
        '
        Me.dsp_RcpEditPressureDrop.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpEditPressureDrop.Name = "dsp_RcpEditPressureDrop"
        Me.dsp_RcpEditPressureDrop.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPressureDrop.TabIndex = 25
        Me.dsp_RcpEditPressureDrop.Text = "Back Pressure-2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa) :"
        Me.dsp_RcpEditPressureDrop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(150, 40)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Prep Fill Time (s) :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditPrepPressure
        '
        Me.dsp_RcpEditPrepPressure.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpEditPrepPressure.Name = "dsp_RcpEditPrepPressure"
        Me.dsp_RcpEditPrepPressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPrepPressure.TabIndex = 26
        Me.dsp_RcpEditPrepPressure.Text = "Back Pressure-1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa) :"
        Me.dsp_RcpEditPrepPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditPrepFlow
        '
        Me.dsp_RcpEditPrepFlow.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpEditPrepFlow.Name = "dsp_RcpEditPrepFlow"
        Me.dsp_RcpEditPrepFlow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPrepFlow.TabIndex = 26
        Me.dsp_RcpEditPrepFlow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpEditPrepFlow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditPrepBleed
        '
        Me.dsp_RcpEditPrepBleed.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpEditPrepBleed.Name = "dsp_RcpEditPrepBleed"
        Me.dsp_RcpEditPrepBleed.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPrepBleed.TabIndex = 27
        Me.dsp_RcpEditPrepBleed.Text = "Prep Air Bleed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Time (s) :"
        Me.dsp_RcpEditPrepBleed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditPrepFill
        '
        Me.dsp_RcpEditPrepFill.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpEditPrepFill.Name = "dsp_RcpEditPrepFill"
        Me.dsp_RcpEditPrepFill.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditPrepFill.TabIndex = 28
        Me.dsp_RcpEditPrepFill.Text = "Prep Fill Time (s) :"
        Me.dsp_RcpEditPrepFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditPrepPressureDropTime
        '
        Me.txtbx_RcpEditPrepPressureDropTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepPressureDropTime.Location = New System.Drawing.Point(183, 306)
        Me.txtbx_RcpEditPrepPressureDropTime.MaxLength = 3
        Me.txtbx_RcpEditPrepPressureDropTime.Name = "txtbx_RcpEditPrepPressureDropTime"
        Me.txtbx_RcpEditPrepPressureDropTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepPressureDropTime.TabIndex = 29
        '
        'txtbx_RcpEditPrepPressureDrop
        '
        Me.txtbx_RcpEditPrepPressureDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepPressureDrop.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpEditPrepPressureDrop.MaxLength = 3
        Me.txtbx_RcpEditPrepPressureDrop.Name = "txtbx_RcpEditPrepPressureDrop"
        Me.txtbx_RcpEditPrepPressureDrop.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepPressureDrop.TabIndex = 30
        '
        'txtbx_RcpEditPrepPressure
        '
        Me.txtbx_RcpEditPrepPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepPressure.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpEditPrepPressure.MaxLength = 3
        Me.txtbx_RcpEditPrepPressure.Name = "txtbx_RcpEditPrepPressure"
        Me.txtbx_RcpEditPrepPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepPressure.TabIndex = 30
        '
        'txtbx_RcpEditPrepFlow
        '
        Me.txtbx_RcpEditPrepFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepFlow.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpEditPrepFlow.MaxLength = 3
        Me.txtbx_RcpEditPrepFlow.Name = "txtbx_RcpEditPrepFlow"
        Me.txtbx_RcpEditPrepFlow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepFlow.TabIndex = 30
        '
        'txtbx_RcpEditPrepBleed
        '
        Me.txtbx_RcpEditPrepBleed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepBleed.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpEditPrepBleed.MaxLength = 3
        Me.txtbx_RcpEditPrepBleed.Name = "txtbx_RcpEditPrepBleed"
        Me.txtbx_RcpEditPrepBleed.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepBleed.TabIndex = 31
        '
        'txtbx_RcpEditPrepFill
        '
        Me.txtbx_RcpEditPrepFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditPrepFill.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpEditPrepFill.MaxLength = 3
        Me.txtbx_RcpEditPrepFill.Name = "txtbx_RcpEditPrepFill"
        Me.txtbx_RcpEditPrepFill.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditPrepFill.TabIndex = 32
        '
        'panel_RcpEditDrain3
        '
        Me.panel_RcpEditDrain3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpEditDrain3.Controls.Add(Me.txtbx_RcpEditDrain3Time)
        Me.panel_RcpEditDrain3.Controls.Add(Me.dsp_RcpEditDrain3Time)
        Me.panel_RcpEditDrain3.Controls.Add(Me.txtbx_RcpEditDrain3Pressure)
        Me.panel_RcpEditDrain3.Controls.Add(Me.dsp_RcpEditDrain3Pressure)
        Me.panel_RcpEditDrain3.Controls.Add(Me.checkbx_EditDrain3)
        Me.panel_RcpEditDrain3.Location = New System.Drawing.Point(1548, 491)
        Me.panel_RcpEditDrain3.Name = "panel_RcpEditDrain3"
        Me.panel_RcpEditDrain3.Size = New System.Drawing.Size(307, 172)
        Me.panel_RcpEditDrain3.TabIndex = 30
        '
        'txtbx_RcpEditDrain3Time
        '
        Me.txtbx_RcpEditDrain3Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDrain3Time.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpEditDrain3Time.MaxLength = 3
        Me.txtbx_RcpEditDrain3Time.Name = "txtbx_RcpEditDrain3Time"
        Me.txtbx_RcpEditDrain3Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDrain3Time.TabIndex = 15
        '
        'dsp_RcpEditDrain3Time
        '
        Me.dsp_RcpEditDrain3Time.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpEditDrain3Time.Name = "dsp_RcpEditDrain3Time"
        Me.dsp_RcpEditDrain3Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDrain3Time.TabIndex = 14
        Me.dsp_RcpEditDrain3Time.Text = "Drain-3 Time :"
        Me.dsp_RcpEditDrain3Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDrain3Pressure
        '
        Me.txtbx_RcpEditDrain3Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDrain3Pressure.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpEditDrain3Pressure.MaxLength = 4
        Me.txtbx_RcpEditDrain3Pressure.Name = "txtbx_RcpEditDrain3Pressure"
        Me.txtbx_RcpEditDrain3Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDrain3Pressure.TabIndex = 11
        '
        'dsp_RcpEditDrain3Pressure
        '
        Me.dsp_RcpEditDrain3Pressure.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpEditDrain3Pressure.Name = "dsp_RcpEditDrain3Pressure"
        Me.dsp_RcpEditDrain3Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDrain3Pressure.TabIndex = 10
        Me.dsp_RcpEditDrain3Pressure.Text = "Drain-3 N2 Purge Pressure (kPa) :"
        Me.dsp_RcpEditDrain3Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkbx_EditDrain3
        '
        Me.checkbx_EditDrain3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_EditDrain3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_EditDrain3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_EditDrain3.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_EditDrain3.Name = "checkbx_EditDrain3"
        Me.checkbx_EditDrain3.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_EditDrain3.TabIndex = 7
        Me.checkbx_EditDrain3.Text = "Drain-3 Enable"
        Me.checkbx_EditDrain3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_EditDrain3.UseVisualStyleBackColor = True
        '
        'panel_RcpEditDrain2
        '
        Me.panel_RcpEditDrain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpEditDrain2.Controls.Add(Me.txtbx_RcpEditDrain2Time)
        Me.panel_RcpEditDrain2.Controls.Add(Me.dsp_RcpEditDrain2Time)
        Me.panel_RcpEditDrain2.Controls.Add(Me.txtbx_RcpEditDrain2Pressure)
        Me.panel_RcpEditDrain2.Controls.Add(Me.dsp_RcpEditDrain2Pressure)
        Me.panel_RcpEditDrain2.Controls.Add(Me.checkbx_EditDrain2)
        Me.panel_RcpEditDrain2.Location = New System.Drawing.Point(1549, 313)
        Me.panel_RcpEditDrain2.Name = "panel_RcpEditDrain2"
        Me.panel_RcpEditDrain2.Size = New System.Drawing.Size(307, 172)
        Me.panel_RcpEditDrain2.TabIndex = 31
        '
        'txtbx_RcpEditDrain2Time
        '
        Me.txtbx_RcpEditDrain2Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDrain2Time.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpEditDrain2Time.MaxLength = 3
        Me.txtbx_RcpEditDrain2Time.Name = "txtbx_RcpEditDrain2Time"
        Me.txtbx_RcpEditDrain2Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDrain2Time.TabIndex = 15
        '
        'dsp_RcpEditDrain2Time
        '
        Me.dsp_RcpEditDrain2Time.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpEditDrain2Time.Name = "dsp_RcpEditDrain2Time"
        Me.dsp_RcpEditDrain2Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDrain2Time.TabIndex = 14
        Me.dsp_RcpEditDrain2Time.Text = "Drain-2 Time :"
        Me.dsp_RcpEditDrain2Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDrain2Pressure
        '
        Me.txtbx_RcpEditDrain2Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDrain2Pressure.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpEditDrain2Pressure.MaxLength = 4
        Me.txtbx_RcpEditDrain2Pressure.Name = "txtbx_RcpEditDrain2Pressure"
        Me.txtbx_RcpEditDrain2Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDrain2Pressure.TabIndex = 11
        '
        'dsp_RcpEditDrain2Pressure
        '
        Me.dsp_RcpEditDrain2Pressure.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpEditDrain2Pressure.Name = "dsp_RcpEditDrain2Pressure"
        Me.dsp_RcpEditDrain2Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDrain2Pressure.TabIndex = 10
        Me.dsp_RcpEditDrain2Pressure.Text = "Drain-2 N2 Purge Pressure (kPa) :"
        Me.dsp_RcpEditDrain2Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkbx_EditDrain2
        '
        Me.checkbx_EditDrain2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_EditDrain2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_EditDrain2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_EditDrain2.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_EditDrain2.Name = "checkbx_EditDrain2"
        Me.checkbx_EditDrain2.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_EditDrain2.TabIndex = 7
        Me.checkbx_EditDrain2.Text = "Drain-2 Enable"
        Me.checkbx_EditDrain2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_EditDrain2.UseVisualStyleBackColor = True
        '
        'panel_RcpEditFlush2
        '
        Me.panel_RcpEditFlush2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpEditFlush2.Controls.Add(Me.checkbx_EditFlush2)
        Me.panel_RcpEditFlush2.Controls.Add(Me.txtbx_RcpEditFlush2Time)
        Me.panel_RcpEditFlush2.Controls.Add(Me.dsp_RcpEditFlush2Time)
        Me.panel_RcpEditFlush2.Controls.Add(Me.txtbx_RcpEditFlush2Stabilize)
        Me.panel_RcpEditFlush2.Controls.Add(Me.dsp_RcpEditFlush2Stabilize)
        Me.panel_RcpEditFlush2.Controls.Add(Me.txtbx_RcpEditFlush2Pressure)
        Me.panel_RcpEditFlush2.Controls.Add(Me.dsp_RcpEditFlush2Pressure)
        Me.panel_RcpEditFlush2.Controls.Add(Me.txtbx_RcpEditFlush2FlowTol)
        Me.panel_RcpEditFlush2.Controls.Add(Me.dsp_RcpEditFlush2FlowTol)
        Me.panel_RcpEditFlush2.Controls.Add(Me.txtbx_RcpEditFlush2Flow)
        Me.panel_RcpEditFlush2.Controls.Add(Me.dsp_RcpEditFlush2Flow)
        Me.panel_RcpEditFlush2.Location = New System.Drawing.Point(900, 451)
        Me.panel_RcpEditFlush2.Name = "panel_RcpEditFlush2"
        Me.panel_RcpEditFlush2.Size = New System.Drawing.Size(307, 310)
        Me.panel_RcpEditFlush2.TabIndex = 27
        '
        'checkbx_EditFlush2
        '
        Me.checkbx_EditFlush2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_EditFlush2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_EditFlush2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_EditFlush2.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_EditFlush2.Name = "checkbx_EditFlush2"
        Me.checkbx_EditFlush2.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_EditFlush2.TabIndex = 7
        Me.checkbx_EditFlush2.Text = "Flush-2 Enable"
        Me.checkbx_EditFlush2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_EditFlush2.UseVisualStyleBackColor = True
        '
        'txtbx_RcpEditFlush2Time
        '
        Me.txtbx_RcpEditFlush2Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush2Time.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpEditFlush2Time.MaxLength = 3
        Me.txtbx_RcpEditFlush2Time.Name = "txtbx_RcpEditFlush2Time"
        Me.txtbx_RcpEditFlush2Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush2Time.TabIndex = 15
        '
        'dsp_RcpEditFlush2Time
        '
        Me.dsp_RcpEditFlush2Time.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpEditFlush2Time.Name = "dsp_RcpEditFlush2Time"
        Me.dsp_RcpEditFlush2Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush2Time.TabIndex = 14
        Me.dsp_RcpEditFlush2Time.Text = "Flush-2 Time (s) :"
        Me.dsp_RcpEditFlush2Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush2Stabilize
        '
        Me.txtbx_RcpEditFlush2Stabilize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush2Stabilize.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpEditFlush2Stabilize.MaxLength = 3
        Me.txtbx_RcpEditFlush2Stabilize.Name = "txtbx_RcpEditFlush2Stabilize"
        Me.txtbx_RcpEditFlush2Stabilize.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush2Stabilize.TabIndex = 13
        '
        'dsp_RcpEditFlush2Stabilize
        '
        Me.dsp_RcpEditFlush2Stabilize.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpEditFlush2Stabilize.Name = "dsp_RcpEditFlush2Stabilize"
        Me.dsp_RcpEditFlush2Stabilize.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush2Stabilize.TabIndex = 12
        Me.dsp_RcpEditFlush2Stabilize.Text = "Flush-2 Stabilize Time (s) :"
        Me.dsp_RcpEditFlush2Stabilize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush2Pressure
        '
        Me.txtbx_RcpEditFlush2Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush2Pressure.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpEditFlush2Pressure.MaxLength = 5
        Me.txtbx_RcpEditFlush2Pressure.Name = "txtbx_RcpEditFlush2Pressure"
        Me.txtbx_RcpEditFlush2Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush2Pressure.TabIndex = 11
        '
        'dsp_RcpEditFlush2Pressure
        '
        Me.dsp_RcpEditFlush2Pressure.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpEditFlush2Pressure.Name = "dsp_RcpEditFlush2Pressure"
        Me.dsp_RcpEditFlush2Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush2Pressure.TabIndex = 10
        Me.dsp_RcpEditFlush2Pressure.Text = "Back Pressure (kPa) :"
        Me.dsp_RcpEditFlush2Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush2FlowTol
        '
        Me.txtbx_RcpEditFlush2FlowTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush2FlowTol.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpEditFlush2FlowTol.MaxLength = 3
        Me.txtbx_RcpEditFlush2FlowTol.Name = "txtbx_RcpEditFlush2FlowTol"
        Me.txtbx_RcpEditFlush2FlowTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush2FlowTol.TabIndex = 9
        '
        'dsp_RcpEditFlush2FlowTol
        '
        Me.dsp_RcpEditFlush2FlowTol.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpEditFlush2FlowTol.Name = "dsp_RcpEditFlush2FlowTol"
        Me.dsp_RcpEditFlush2FlowTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush2FlowTol.TabIndex = 8
        Me.dsp_RcpEditFlush2FlowTol.Text = "Flowrate Tolerance (l/min) (+/-) :"
        Me.dsp_RcpEditFlush2FlowTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush2Flow
        '
        Me.txtbx_RcpEditFlush2Flow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush2Flow.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpEditFlush2Flow.MaxLength = 4
        Me.txtbx_RcpEditFlush2Flow.Name = "txtbx_RcpEditFlush2Flow"
        Me.txtbx_RcpEditFlush2Flow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush2Flow.TabIndex = 7
        '
        'dsp_RcpEditFlush2Flow
        '
        Me.dsp_RcpEditFlush2Flow.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpEditFlush2Flow.Name = "dsp_RcpEditFlush2Flow"
        Me.dsp_RcpEditFlush2Flow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush2Flow.TabIndex = 6
        Me.dsp_RcpEditFlush2Flow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpEditFlush2Flow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel18
        '
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.txtbx_RcpEditVerTol)
        Me.Panel18.Controls.Add(Me.dsp_RcpEditVerTol)
        Me.Panel18.Location = New System.Drawing.Point(575, 45)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(1280, 80)
        Me.Panel18.TabIndex = 33
        '
        'txtbx_RcpEditVerTol
        '
        Me.txtbx_RcpEditVerTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditVerTol.Location = New System.Drawing.Point(183, 30)
        Me.txtbx_RcpEditVerTol.MaxLength = 3
        Me.txtbx_RcpEditVerTol.Name = "txtbx_RcpEditVerTol"
        Me.txtbx_RcpEditVerTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditVerTol.TabIndex = 7
        '
        'dsp_RcpEditVerTol
        '
        Me.dsp_RcpEditVerTol.Location = New System.Drawing.Point(17, 20)
        Me.dsp_RcpEditVerTol.Name = "dsp_RcpEditVerTol"
        Me.dsp_RcpEditVerTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditVerTol.TabIndex = 6
        Me.dsp_RcpEditVerTol.Text = "Verification Tolerance (kPa) (+/-) :"
        Me.dsp_RcpEditVerTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_RcpEditDrain1
        '
        Me.panel_RcpEditDrain1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpEditDrain1.Controls.Add(Me.txtbx_RcpEditDrain1Time)
        Me.panel_RcpEditDrain1.Controls.Add(Me.dsp_RcpEditDrain1Time)
        Me.panel_RcpEditDrain1.Controls.Add(Me.txtbx_RcpEditDrain1Pressure)
        Me.panel_RcpEditDrain1.Controls.Add(Me.dsp_RcpEditDrain1Pressure)
        Me.panel_RcpEditDrain1.Controls.Add(Me.checkbx_EditDrain1)
        Me.panel_RcpEditDrain1.Location = New System.Drawing.Point(1548, 135)
        Me.panel_RcpEditDrain1.Name = "panel_RcpEditDrain1"
        Me.panel_RcpEditDrain1.Size = New System.Drawing.Size(307, 172)
        Me.panel_RcpEditDrain1.TabIndex = 28
        '
        'txtbx_RcpEditDrain1Time
        '
        Me.txtbx_RcpEditDrain1Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDrain1Time.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpEditDrain1Time.MaxLength = 3
        Me.txtbx_RcpEditDrain1Time.Name = "txtbx_RcpEditDrain1Time"
        Me.txtbx_RcpEditDrain1Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDrain1Time.TabIndex = 15
        '
        'dsp_RcpEditDrain1Time
        '
        Me.dsp_RcpEditDrain1Time.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpEditDrain1Time.Name = "dsp_RcpEditDrain1Time"
        Me.dsp_RcpEditDrain1Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDrain1Time.TabIndex = 14
        Me.dsp_RcpEditDrain1Time.Text = "Drain-1 Time :"
        Me.dsp_RcpEditDrain1Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDrain1Pressure
        '
        Me.txtbx_RcpEditDrain1Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDrain1Pressure.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpEditDrain1Pressure.MaxLength = 4
        Me.txtbx_RcpEditDrain1Pressure.Name = "txtbx_RcpEditDrain1Pressure"
        Me.txtbx_RcpEditDrain1Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDrain1Pressure.TabIndex = 11
        '
        'dsp_RcpEditDrain1Pressure
        '
        Me.dsp_RcpEditDrain1Pressure.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpEditDrain1Pressure.Name = "dsp_RcpEditDrain1Pressure"
        Me.dsp_RcpEditDrain1Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDrain1Pressure.TabIndex = 10
        Me.dsp_RcpEditDrain1Pressure.Text = "Drain-1 N2 Purge Pressure (kPa) :"
        Me.dsp_RcpEditDrain1Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkbx_EditDrain1
        '
        Me.checkbx_EditDrain1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_EditDrain1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_EditDrain1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_EditDrain1.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_EditDrain1.Name = "checkbx_EditDrain1"
        Me.checkbx_EditDrain1.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_EditDrain1.TabIndex = 7
        Me.checkbx_EditDrain1.Text = "Drain-1 Enable"
        Me.checkbx_EditDrain1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_EditDrain1.UseVisualStyleBackColor = True
        '
        'panel_RcpEditDPTest1
        '
        Me.panel_RcpEditDPTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpEditDPTest1.Controls.Add(Me.checkbx_EditDPTest2)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.checkbx_EditDPTest1)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPPoints)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPPoints)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPUpLimit)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPUpLimit)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPLowLimit)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPLowLimit)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPTime)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPTime)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPStabilize)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPStabilize)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPPressure)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPPressure)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPFlowTol)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPFlowTol)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.txtbx_RcpEditDPFlow)
        Me.panel_RcpEditDPTest1.Controls.Add(Me.dsp_RcpEditDPFlow)
        Me.panel_RcpEditDPTest1.Location = New System.Drawing.Point(1224, 135)
        Me.panel_RcpEditDPTest1.Name = "panel_RcpEditDPTest1"
        Me.panel_RcpEditDPTest1.Size = New System.Drawing.Size(307, 528)
        Me.panel_RcpEditDPTest1.TabIndex = 29
        '
        'checkbx_EditDPTest2
        '
        Me.checkbx_EditDPTest2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_EditDPTest2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_EditDPTest2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_EditDPTest2.Location = New System.Drawing.Point(49, 58)
        Me.checkbx_EditDPTest2.Name = "checkbx_EditDPTest2"
        Me.checkbx_EditDPTest2.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_EditDPTest2.TabIndex = 7
        Me.checkbx_EditDPTest2.Text = "DP Test-2 Enable"
        Me.checkbx_EditDPTest2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_EditDPTest2.UseVisualStyleBackColor = True
        '
        'checkbx_EditDPTest1
        '
        Me.checkbx_EditDPTest1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_EditDPTest1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_EditDPTest1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_EditDPTest1.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_EditDPTest1.Name = "checkbx_EditDPTest1"
        Me.checkbx_EditDPTest1.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_EditDPTest1.TabIndex = 7
        Me.checkbx_EditDPTest1.Text = "DP Test-1 Enable"
        Me.checkbx_EditDPTest1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_EditDPTest1.UseVisualStyleBackColor = True
        '
        'txtbx_RcpEditDPPoints
        '
        Me.txtbx_RcpEditDPPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPPoints.Location = New System.Drawing.Point(183, 450)
        Me.txtbx_RcpEditDPPoints.MaxLength = 2
        Me.txtbx_RcpEditDPPoints.Name = "txtbx_RcpEditDPPoints"
        Me.txtbx_RcpEditDPPoints.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPPoints.TabIndex = 21
        '
        'dsp_RcpEditDPPoints
        '
        Me.dsp_RcpEditDPPoints.Location = New System.Drawing.Point(17, 442)
        Me.dsp_RcpEditDPPoints.Name = "dsp_RcpEditDPPoints"
        Me.dsp_RcpEditDPPoints.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPPoints.TabIndex = 20
        Me.dsp_RcpEditDPPoints.Text = "Number of Test Points :"
        Me.dsp_RcpEditDPPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDPUpLimit
        '
        Me.txtbx_RcpEditDPUpLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPUpLimit.Location = New System.Drawing.Point(183, 402)
        Me.txtbx_RcpEditDPUpLimit.MaxLength = 5
        Me.txtbx_RcpEditDPUpLimit.Name = "txtbx_RcpEditDPUpLimit"
        Me.txtbx_RcpEditDPUpLimit.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPUpLimit.TabIndex = 19
        '
        'dsp_RcpEditDPUpLimit
        '
        Me.dsp_RcpEditDPUpLimit.Location = New System.Drawing.Point(17, 394)
        Me.dsp_RcpEditDPUpLimit.Name = "dsp_RcpEditDPUpLimit"
        Me.dsp_RcpEditDPUpLimit.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPUpLimit.TabIndex = 18
        Me.dsp_RcpEditDPUpLimit.Text = "DP Upper Limit (kPa) :"
        Me.dsp_RcpEditDPUpLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDPLowLimit
        '
        Me.txtbx_RcpEditDPLowLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPLowLimit.Location = New System.Drawing.Point(183, 354)
        Me.txtbx_RcpEditDPLowLimit.MaxLength = 5
        Me.txtbx_RcpEditDPLowLimit.Name = "txtbx_RcpEditDPLowLimit"
        Me.txtbx_RcpEditDPLowLimit.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPLowLimit.TabIndex = 17
        '
        'dsp_RcpEditDPLowLimit
        '
        Me.dsp_RcpEditDPLowLimit.Location = New System.Drawing.Point(17, 346)
        Me.dsp_RcpEditDPLowLimit.Name = "dsp_RcpEditDPLowLimit"
        Me.dsp_RcpEditDPLowLimit.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPLowLimit.TabIndex = 16
        Me.dsp_RcpEditDPLowLimit.Text = "DP Lower Limit (kPa)  :"
        Me.dsp_RcpEditDPLowLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDPTime
        '
        Me.txtbx_RcpEditDPTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPTime.Location = New System.Drawing.Point(183, 306)
        Me.txtbx_RcpEditDPTime.MaxLength = 3
        Me.txtbx_RcpEditDPTime.Name = "txtbx_RcpEditDPTime"
        Me.txtbx_RcpEditDPTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPTime.TabIndex = 15
        '
        'dsp_RcpEditDPTime
        '
        Me.dsp_RcpEditDPTime.Location = New System.Drawing.Point(17, 298)
        Me.dsp_RcpEditDPTime.Name = "dsp_RcpEditDPTime"
        Me.dsp_RcpEditDPTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPTime.TabIndex = 14
        Me.dsp_RcpEditDPTime.Text = "DP Time (s) :"
        Me.dsp_RcpEditDPTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDPStabilize
        '
        Me.txtbx_RcpEditDPStabilize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPStabilize.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpEditDPStabilize.MaxLength = 3
        Me.txtbx_RcpEditDPStabilize.Name = "txtbx_RcpEditDPStabilize"
        Me.txtbx_RcpEditDPStabilize.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPStabilize.TabIndex = 13
        '
        'dsp_RcpEditDPStabilize
        '
        Me.dsp_RcpEditDPStabilize.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpEditDPStabilize.Name = "dsp_RcpEditDPStabilize"
        Me.dsp_RcpEditDPStabilize.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPStabilize.TabIndex = 12
        Me.dsp_RcpEditDPStabilize.Text = "DP Stabilize Time (s) :"
        Me.dsp_RcpEditDPStabilize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDPPressure
        '
        Me.txtbx_RcpEditDPPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPPressure.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpEditDPPressure.MaxLength = 5
        Me.txtbx_RcpEditDPPressure.Name = "txtbx_RcpEditDPPressure"
        Me.txtbx_RcpEditDPPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPPressure.TabIndex = 11
        '
        'dsp_RcpEditDPPressure
        '
        Me.dsp_RcpEditDPPressure.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpEditDPPressure.Name = "dsp_RcpEditDPPressure"
        Me.dsp_RcpEditDPPressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPPressure.TabIndex = 10
        Me.dsp_RcpEditDPPressure.Text = "Back Pressure (kPa) :"
        Me.dsp_RcpEditDPPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDPFlowTol
        '
        Me.txtbx_RcpEditDPFlowTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPFlowTol.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpEditDPFlowTol.MaxLength = 3
        Me.txtbx_RcpEditDPFlowTol.Name = "txtbx_RcpEditDPFlowTol"
        Me.txtbx_RcpEditDPFlowTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPFlowTol.TabIndex = 9
        '
        'dsp_RcpEditDPFlowTol
        '
        Me.dsp_RcpEditDPFlowTol.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpEditDPFlowTol.Name = "dsp_RcpEditDPFlowTol"
        Me.dsp_RcpEditDPFlowTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPFlowTol.TabIndex = 8
        Me.dsp_RcpEditDPFlowTol.Text = "Flowrate Tolerance (l/min) (+/-) :"
        Me.dsp_RcpEditDPFlowTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditDPFlow
        '
        Me.txtbx_RcpEditDPFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditDPFlow.Location = New System.Drawing.Point(183, 116)
        Me.txtbx_RcpEditDPFlow.MaxLength = 4
        Me.txtbx_RcpEditDPFlow.Name = "txtbx_RcpEditDPFlow"
        Me.txtbx_RcpEditDPFlow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditDPFlow.TabIndex = 7
        '
        'dsp_RcpEditDPFlow
        '
        Me.dsp_RcpEditDPFlow.Location = New System.Drawing.Point(17, 108)
        Me.dsp_RcpEditDPFlow.Name = "dsp_RcpEditDPFlow"
        Me.dsp_RcpEditDPFlow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditDPFlow.TabIndex = 6
        Me.dsp_RcpEditDPFlow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpEditDPFlow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_RcpEditFlush1
        '
        Me.panel_RcpEditFlush1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpEditFlush1.Controls.Add(Me.txtbx_RcpEditFlush1Time)
        Me.panel_RcpEditFlush1.Controls.Add(Me.dsp_RcpEditFlush1Time)
        Me.panel_RcpEditFlush1.Controls.Add(Me.txtbx_RcpEditFlush1Stabilize)
        Me.panel_RcpEditFlush1.Controls.Add(Me.dsp_RcpEditFlush1Stabilize)
        Me.panel_RcpEditFlush1.Controls.Add(Me.txtbx_RcpEditFlush1Pressure)
        Me.panel_RcpEditFlush1.Controls.Add(Me.dsp_RcpEditFlush1Pressure)
        Me.panel_RcpEditFlush1.Controls.Add(Me.txtbx_RcpEditFlush1FlowTol)
        Me.panel_RcpEditFlush1.Controls.Add(Me.dsp_RcpEditFlush1FlowTol)
        Me.panel_RcpEditFlush1.Controls.Add(Me.txtbx_RcpEditFlush1Flow)
        Me.panel_RcpEditFlush1.Controls.Add(Me.checkbx_EditFlush1)
        Me.panel_RcpEditFlush1.Controls.Add(Me.dsp_RcpEditFlush1Flow)
        Me.panel_RcpEditFlush1.Location = New System.Drawing.Point(900, 135)
        Me.panel_RcpEditFlush1.Name = "panel_RcpEditFlush1"
        Me.panel_RcpEditFlush1.Size = New System.Drawing.Size(307, 310)
        Me.panel_RcpEditFlush1.TabIndex = 26
        '
        'txtbx_RcpEditFlush1Time
        '
        Me.txtbx_RcpEditFlush1Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush1Time.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpEditFlush1Time.MaxLength = 3
        Me.txtbx_RcpEditFlush1Time.Name = "txtbx_RcpEditFlush1Time"
        Me.txtbx_RcpEditFlush1Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush1Time.TabIndex = 15
        '
        'dsp_RcpEditFlush1Time
        '
        Me.dsp_RcpEditFlush1Time.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpEditFlush1Time.Name = "dsp_RcpEditFlush1Time"
        Me.dsp_RcpEditFlush1Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush1Time.TabIndex = 14
        Me.dsp_RcpEditFlush1Time.Text = "Flush-1 Time (s) :"
        Me.dsp_RcpEditFlush1Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush1Stabilize
        '
        Me.txtbx_RcpEditFlush1Stabilize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush1Stabilize.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpEditFlush1Stabilize.MaxLength = 3
        Me.txtbx_RcpEditFlush1Stabilize.Name = "txtbx_RcpEditFlush1Stabilize"
        Me.txtbx_RcpEditFlush1Stabilize.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush1Stabilize.TabIndex = 13
        '
        'dsp_RcpEditFlush1Stabilize
        '
        Me.dsp_RcpEditFlush1Stabilize.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpEditFlush1Stabilize.Name = "dsp_RcpEditFlush1Stabilize"
        Me.dsp_RcpEditFlush1Stabilize.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush1Stabilize.TabIndex = 12
        Me.dsp_RcpEditFlush1Stabilize.Text = "Flush-1 Stabilize Time (s) :"
        Me.dsp_RcpEditFlush1Stabilize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush1Pressure
        '
        Me.txtbx_RcpEditFlush1Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush1Pressure.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpEditFlush1Pressure.MaxLength = 5
        Me.txtbx_RcpEditFlush1Pressure.Name = "txtbx_RcpEditFlush1Pressure"
        Me.txtbx_RcpEditFlush1Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush1Pressure.TabIndex = 11
        '
        'dsp_RcpEditFlush1Pressure
        '
        Me.dsp_RcpEditFlush1Pressure.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpEditFlush1Pressure.Name = "dsp_RcpEditFlush1Pressure"
        Me.dsp_RcpEditFlush1Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush1Pressure.TabIndex = 10
        Me.dsp_RcpEditFlush1Pressure.Text = "Back Pressure (kPa) :"
        Me.dsp_RcpEditFlush1Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush1FlowTol
        '
        Me.txtbx_RcpEditFlush1FlowTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush1FlowTol.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpEditFlush1FlowTol.MaxLength = 3
        Me.txtbx_RcpEditFlush1FlowTol.Name = "txtbx_RcpEditFlush1FlowTol"
        Me.txtbx_RcpEditFlush1FlowTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush1FlowTol.TabIndex = 9
        '
        'dsp_RcpEditFlush1FlowTol
        '
        Me.dsp_RcpEditFlush1FlowTol.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpEditFlush1FlowTol.Name = "dsp_RcpEditFlush1FlowTol"
        Me.dsp_RcpEditFlush1FlowTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush1FlowTol.TabIndex = 8
        Me.dsp_RcpEditFlush1FlowTol.Text = "Flowrate Tolerance (l/min) (+/-) :"
        Me.dsp_RcpEditFlush1FlowTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpEditFlush1Flow
        '
        Me.txtbx_RcpEditFlush1Flow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpEditFlush1Flow.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpEditFlush1Flow.MaxLength = 4
        Me.txtbx_RcpEditFlush1Flow.Name = "txtbx_RcpEditFlush1Flow"
        Me.txtbx_RcpEditFlush1Flow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpEditFlush1Flow.TabIndex = 7
        '
        'checkbx_EditFlush1
        '
        Me.checkbx_EditFlush1.BackColor = System.Drawing.Color.Transparent
        Me.checkbx_EditFlush1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_EditFlush1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_EditFlush1.FlatAppearance.CheckedBackColor = System.Drawing.Color.RoyalBlue
        Me.checkbx_EditFlush1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_EditFlush1.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_EditFlush1.Name = "checkbx_EditFlush1"
        Me.checkbx_EditFlush1.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_EditFlush1.TabIndex = 7
        Me.checkbx_EditFlush1.Text = "Flush-1 Enable"
        Me.checkbx_EditFlush1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_EditFlush1.UseVisualStyleBackColor = False
        '
        'dsp_RcpEditFlush1Flow
        '
        Me.dsp_RcpEditFlush1Flow.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpEditFlush1Flow.Name = "dsp_RcpEditFlush1Flow"
        Me.dsp_RcpEditFlush1Flow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpEditFlush1Flow.TabIndex = 6
        Me.dsp_RcpEditFlush1Flow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpEditFlush1Flow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditRcpParameters
        '
        Me.dsp_RcpEditRcpParameters.AutoSize = True
        Me.dsp_RcpEditRcpParameters.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpEditRcpParameters.Location = New System.Drawing.Point(1154, 4)
        Me.dsp_RcpEditRcpParameters.Name = "dsp_RcpEditRcpParameters"
        Me.dsp_RcpEditRcpParameters.Size = New System.Drawing.Size(188, 30)
        Me.dsp_RcpEditRcpParameters.TabIndex = 25
        Me.dsp_RcpEditRcpParameters.Text = "Recipe Parameters"
        Me.dsp_RcpEditRcpParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel_Edit
        '
        Me.panel_Edit.Controls.Add(Me.Panel1)
        Me.panel_Edit.Controls.Add(Me.btn_EditDiscard)
        Me.panel_Edit.Controls.Add(Me.btn_RcpEditSave)
        Me.panel_Edit.Controls.Add(Me.panel_RecipeManagement)
        Me.panel_Edit.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel_Edit.Location = New System.Drawing.Point(0, 0)
        Me.panel_Edit.Name = "panel_Edit"
        Me.panel_Edit.Size = New System.Drawing.Size(562, 767)
        Me.panel_Edit.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dsp_RcpDuplication)
        Me.Panel1.Controls.Add(Me.btn_RcpDuplicate)
        Me.Panel1.Controls.Add(Me.txtbx_RcpDupNewRecipeID)
        Me.Panel1.Controls.Add(Me.dsp_RcpDupNewRecipeID)
        Me.Panel1.Controls.Add(Me.dsp_RcpDupNewType)
        Me.Panel1.Controls.Add(Me.dsp_RcpDupSelRecipe)
        Me.Panel1.Controls.Add(Me.Cmbx_RcpDupNewType)
        Me.Panel1.Controls.Add(Me.cmbx_RcpDupSelRecipe)
        Me.Panel1.Location = New System.Drawing.Point(3, 227)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(556, 255)
        Me.Panel1.TabIndex = 109
        '
        'dsp_RcpDuplication
        '
        Me.dsp_RcpDuplication.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpDuplication.Location = New System.Drawing.Point(0, 0)
        Me.dsp_RcpDuplication.Name = "dsp_RcpDuplication"
        Me.dsp_RcpDuplication.Size = New System.Drawing.Size(554, 50)
        Me.dsp_RcpDuplication.TabIndex = 106
        Me.dsp_RcpDuplication.Text = "Recipe Duplication"
        Me.dsp_RcpDuplication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_RcpDuplicate
        '
        Me.btn_RcpDuplicate.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_RcpDuplicate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_RcpDuplicate.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RcpDuplicate.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_RcpDuplicate.Location = New System.Drawing.Point(423, 86)
        Me.btn_RcpDuplicate.Name = "btn_RcpDuplicate"
        Me.btn_RcpDuplicate.Size = New System.Drawing.Size(110, 60)
        Me.btn_RcpDuplicate.TabIndex = 105
        Me.btn_RcpDuplicate.Text = "Duplicate"
        Me.btn_RcpDuplicate.UseVisualStyleBackColor = False
        '
        'txtbx_RcpDupNewRecipeID
        '
        Me.txtbx_RcpDupNewRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_RcpDupNewRecipeID.Location = New System.Drawing.Point(152, 147)
        Me.txtbx_RcpDupNewRecipeID.MaxLength = 20
        Me.txtbx_RcpDupNewRecipeID.Name = "txtbx_RcpDupNewRecipeID"
        Me.txtbx_RcpDupNewRecipeID.Size = New System.Drawing.Size(250, 29)
        Me.txtbx_RcpDupNewRecipeID.TabIndex = 107
        '
        'dsp_RcpDupNewRecipeID
        '
        Me.dsp_RcpDupNewRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpDupNewRecipeID.Location = New System.Drawing.Point(21, 148)
        Me.dsp_RcpDupNewRecipeID.Name = "dsp_RcpDupNewRecipeID"
        Me.dsp_RcpDupNewRecipeID.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpDupNewRecipeID.TabIndex = 104
        Me.dsp_RcpDupNewRecipeID.Text = "New Recipe ID :"
        Me.dsp_RcpDupNewRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpDupNewType
        '
        Me.dsp_RcpDupNewType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpDupNewType.Location = New System.Drawing.Point(21, 103)
        Me.dsp_RcpDupNewType.Name = "dsp_RcpDupNewType"
        Me.dsp_RcpDupNewType.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpDupNewType.TabIndex = 104
        Me.dsp_RcpDupNewType.Text = "New Type :"
        Me.dsp_RcpDupNewType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpDupSelRecipe
        '
        Me.dsp_RcpDupSelRecipe.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpDupSelRecipe.Location = New System.Drawing.Point(21, 58)
        Me.dsp_RcpDupSelRecipe.Name = "dsp_RcpDupSelRecipe"
        Me.dsp_RcpDupSelRecipe.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpDupSelRecipe.TabIndex = 104
        Me.dsp_RcpDupSelRecipe.Text = "Recipe ID :"
        Me.dsp_RcpDupSelRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmbx_RcpDupNewType
        '
        Me.Cmbx_RcpDupNewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbx_RcpDupNewType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbx_RcpDupNewType.FormattingEnabled = True
        Me.Cmbx_RcpDupNewType.Location = New System.Drawing.Point(152, 102)
        Me.Cmbx_RcpDupNewType.Name = "Cmbx_RcpDupNewType"
        Me.Cmbx_RcpDupNewType.Size = New System.Drawing.Size(250, 29)
        Me.Cmbx_RcpDupNewType.TabIndex = 12
        '
        'cmbx_RcpDupSelRecipe
        '
        Me.cmbx_RcpDupSelRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpDupSelRecipe.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpDupSelRecipe.FormattingEnabled = True
        Me.cmbx_RcpDupSelRecipe.Location = New System.Drawing.Point(152, 57)
        Me.cmbx_RcpDupSelRecipe.Name = "cmbx_RcpDupSelRecipe"
        Me.cmbx_RcpDupSelRecipe.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpDupSelRecipe.TabIndex = 11
        '
        'btn_EditDiscard
        '
        Me.btn_EditDiscard.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_EditDiscard.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EditDiscard.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_EditDiscard.Location = New System.Drawing.Point(304, 675)
        Me.btn_EditDiscard.Name = "btn_EditDiscard"
        Me.btn_EditDiscard.Size = New System.Drawing.Size(200, 60)
        Me.btn_EditDiscard.TabIndex = 16
        Me.btn_EditDiscard.Text = "Discard"
        Me.btn_EditDiscard.UseVisualStyleBackColor = False
        '
        'btn_RcpEditSave
        '
        Me.btn_RcpEditSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_RcpEditSave.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RcpEditSave.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_RcpEditSave.Location = New System.Drawing.Point(63, 675)
        Me.btn_RcpEditSave.Name = "btn_RcpEditSave"
        Me.btn_RcpEditSave.Size = New System.Drawing.Size(200, 60)
        Me.btn_RcpEditSave.TabIndex = 15
        Me.btn_RcpEditSave.Text = "Save Changes"
        Me.btn_RcpEditSave.UseVisualStyleBackColor = False
        '
        'panel_RecipeManagement
        '
        Me.panel_RecipeManagement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RecipeManagement.Controls.Add(Me.Label16)
        Me.panel_RecipeManagement.Controls.Add(Me.btn_RcpEdit)
        Me.panel_RecipeManagement.Controls.Add(Me.dsp_RcpEditRecipeID)
        Me.panel_RecipeManagement.Controls.Add(Me.dsp_RcpEditPartID)
        Me.panel_RecipeManagement.Controls.Add(Me.dsp_RcpEditFilterType)
        Me.panel_RecipeManagement.Controls.Add(Me.cmbx_RcpEditRecipeID)
        Me.panel_RecipeManagement.Controls.Add(Me.cmbx_RcpEditPartID)
        Me.panel_RecipeManagement.Controls.Add(Me.cmbx_RcpEditFilterType)
        Me.panel_RecipeManagement.Controls.Add(Me.dsp_RcpEditRcpSelection)
        Me.panel_RecipeManagement.Location = New System.Drawing.Point(3, 3)
        Me.panel_RecipeManagement.Name = "panel_RecipeManagement"
        Me.panel_RecipeManagement.Size = New System.Drawing.Size(556, 220)
        Me.panel_RecipeManagement.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(441, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 25)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Edit"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_RcpEdit
        '
        Me.btn_RcpEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_RcpEdit.BackgroundImage = CType(resources.GetObject("btn_RcpEdit.BackgroundImage"), System.Drawing.Image)
        Me.btn_RcpEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_RcpEdit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RcpEdit.Location = New System.Drawing.Point(441, 99)
        Me.btn_RcpEdit.Name = "btn_RcpEdit"
        Me.btn_RcpEdit.Size = New System.Drawing.Size(80, 80)
        Me.btn_RcpEdit.TabIndex = 14
        Me.btn_RcpEdit.UseVisualStyleBackColor = False
        '
        'dsp_RcpEditRecipeID
        '
        Me.dsp_RcpEditRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpEditRecipeID.Location = New System.Drawing.Point(21, 159)
        Me.dsp_RcpEditRecipeID.Name = "dsp_RcpEditRecipeID"
        Me.dsp_RcpEditRecipeID.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpEditRecipeID.TabIndex = 104
        Me.dsp_RcpEditRecipeID.Text = "Recipe ID :"
        Me.dsp_RcpEditRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditPartID
        '
        Me.dsp_RcpEditPartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpEditPartID.Location = New System.Drawing.Point(21, 114)
        Me.dsp_RcpEditPartID.Name = "dsp_RcpEditPartID"
        Me.dsp_RcpEditPartID.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpEditPartID.TabIndex = 104
        Me.dsp_RcpEditPartID.Text = "Part ID :"
        Me.dsp_RcpEditPartID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpEditFilterType
        '
        Me.dsp_RcpEditFilterType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpEditFilterType.Location = New System.Drawing.Point(21, 69)
        Me.dsp_RcpEditFilterType.Name = "dsp_RcpEditFilterType"
        Me.dsp_RcpEditFilterType.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpEditFilterType.TabIndex = 104
        Me.dsp_RcpEditFilterType.Text = "Filter Type :"
        Me.dsp_RcpEditFilterType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbx_RcpEditRecipeID
        '
        Me.cmbx_RcpEditRecipeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpEditRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpEditRecipeID.FormattingEnabled = True
        Me.cmbx_RcpEditRecipeID.Location = New System.Drawing.Point(152, 158)
        Me.cmbx_RcpEditRecipeID.Name = "cmbx_RcpEditRecipeID"
        Me.cmbx_RcpEditRecipeID.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpEditRecipeID.TabIndex = 13
        '
        'cmbx_RcpEditPartID
        '
        Me.cmbx_RcpEditPartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpEditPartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpEditPartID.FormattingEnabled = True
        Me.cmbx_RcpEditPartID.Location = New System.Drawing.Point(152, 113)
        Me.cmbx_RcpEditPartID.Name = "cmbx_RcpEditPartID"
        Me.cmbx_RcpEditPartID.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpEditPartID.TabIndex = 12
        '
        'cmbx_RcpEditFilterType
        '
        Me.cmbx_RcpEditFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpEditFilterType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpEditFilterType.FormattingEnabled = True
        Me.cmbx_RcpEditFilterType.Location = New System.Drawing.Point(152, 68)
        Me.cmbx_RcpEditFilterType.Name = "cmbx_RcpEditFilterType"
        Me.cmbx_RcpEditFilterType.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpEditFilterType.TabIndex = 11
        '
        'dsp_RcpEditRcpSelection
        '
        Me.dsp_RcpEditRcpSelection.Dock = System.Windows.Forms.DockStyle.Top
        Me.dsp_RcpEditRcpSelection.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpEditRcpSelection.Location = New System.Drawing.Point(0, 0)
        Me.dsp_RcpEditRcpSelection.Name = "dsp_RcpEditRcpSelection"
        Me.dsp_RcpEditRcpSelection.Size = New System.Drawing.Size(554, 50)
        Me.dsp_RcpEditRcpSelection.TabIndex = 102
        Me.dsp_RcpEditRcpSelection.Text = "Recipe Selection"
        Me.dsp_RcpEditRcpSelection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabpg_Create
        '
        Me.tabpg_Create.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabpg_Create.Controls.Add(Me.Panel4)
        Me.tabpg_Create.Controls.Add(Me.Panel3)
        Me.tabpg_Create.Controls.Add(Me.panel_RcpCreateDrain3)
        Me.tabpg_Create.Controls.Add(Me.panel_RcpCreateDrain2)
        Me.tabpg_Create.Controls.Add(Me.panel_RcpCreateFlush2)
        Me.tabpg_Create.Controls.Add(Me.Panel8)
        Me.tabpg_Create.Controls.Add(Me.panel_RcpCreateDrain1)
        Me.tabpg_Create.Controls.Add(Me.panel_RcpCreateDPTest1)
        Me.tabpg_Create.Controls.Add(Me.panel_RcpCreateFlush1)
        Me.tabpg_Create.Controls.Add(Me.dsp_RcpCreateRcpParameters)
        Me.tabpg_Create.Controls.Add(Me.panel_Create)
        Me.tabpg_Create.Location = New System.Drawing.Point(4, 44)
        Me.tabpg_Create.Name = "tabpg_Create"
        Me.tabpg_Create.Size = New System.Drawing.Size(1872, 769)
        Me.tabpg_Create.TabIndex = 5
        Me.tabpg_Create.Text = "Create"
        Me.tabpg_Create.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.ComboBox6)
        Me.Panel4.Controls.Add(Me.ComboBox4)
        Me.Panel4.Controls.Add(Me.ComboBox3)
        Me.Panel4.Location = New System.Drawing.Point(575, 591)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(307, 170)
        Me.Panel4.TabIndex = 36
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(49, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(200, 40)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Changeover Part"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(42, 130)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 17)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Blank :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 17)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Outlet :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(48, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Inlet :"
        '
        'ComboBox6
        '
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox6.Location = New System.Drawing.Point(93, 127)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(170, 25)
        Me.ComboBox6.TabIndex = 14
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox4.Location = New System.Drawing.Point(93, 92)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(170, 25)
        Me.ComboBox4.TabIndex = 14
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox3.Location = New System.Drawing.Point(93, 57)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(170, 25)
        Me.ComboBox3.TabIndex = 14
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepPrefillTime)
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepPrefillStartTime)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepPrefillTime)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepPrefillStartTime)
        Me.Panel3.Controls.Add(Me.dsp_CreatePreparation)
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepPressureDropTime)
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepPressureDrop)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepPressure)
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepFlow)
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepBleed)
        Me.Panel3.Controls.Add(Me.dsp_RcpCreatePrepFill)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepPressureDropTime)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepPressureDrop)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepPressure)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepFlow)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepBleed)
        Me.Panel3.Controls.Add(Me.txtbx_RcpCreatePrepFill)
        Me.Panel3.Location = New System.Drawing.Point(575, 135)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(307, 450)
        Me.Panel3.TabIndex = 35
        '
        'dsp_RcpCreatePrepPrefillTime
        '
        Me.dsp_RcpCreatePrepPrefillTime.Location = New System.Drawing.Point(17, 394)
        Me.dsp_RcpCreatePrepPrefillTime.Name = "dsp_RcpCreatePrepPrefillTime"
        Me.dsp_RcpCreatePrepPrefillTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepPrefillTime.TabIndex = 39
        Me.dsp_RcpCreatePrepPrefillTime.Text = "Prep Prefill Vent" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Duration (s) :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.dsp_RcpCreatePrepPrefillTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreatePrepPrefillStartTime
        '
        Me.dsp_RcpCreatePrepPrefillStartTime.Location = New System.Drawing.Point(17, 346)
        Me.dsp_RcpCreatePrepPrefillStartTime.Name = "dsp_RcpCreatePrepPrefillStartTime"
        Me.dsp_RcpCreatePrepPrefillStartTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepPrefillStartTime.TabIndex = 40
        Me.dsp_RcpCreatePrepPrefillStartTime.Text = "Prep Prefill Vent" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Start Time (s) :"
        Me.dsp_RcpCreatePrepPrefillStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreatePrepPrefillTime
        '
        Me.txtbx_RcpCreatePrepPrefillTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepPrefillTime.Location = New System.Drawing.Point(183, 402)
        Me.txtbx_RcpCreatePrepPrefillTime.MaxLength = 3
        Me.txtbx_RcpCreatePrepPrefillTime.Name = "txtbx_RcpCreatePrepPrefillTime"
        Me.txtbx_RcpCreatePrepPrefillTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepPrefillTime.TabIndex = 41
        '
        'txtbx_RcpCreatePrepPrefillStartTime
        '
        Me.txtbx_RcpCreatePrepPrefillStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepPrefillStartTime.Location = New System.Drawing.Point(183, 354)
        Me.txtbx_RcpCreatePrepPrefillStartTime.MaxLength = 3
        Me.txtbx_RcpCreatePrepPrefillStartTime.Name = "txtbx_RcpCreatePrepPrefillStartTime"
        Me.txtbx_RcpCreatePrepPrefillStartTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepPrefillStartTime.TabIndex = 42
        '
        'dsp_CreatePreparation
        '
        Me.dsp_CreatePreparation.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.dsp_CreatePreparation.Location = New System.Drawing.Point(49, 15)
        Me.dsp_CreatePreparation.Name = "dsp_CreatePreparation"
        Me.dsp_CreatePreparation.Size = New System.Drawing.Size(200, 40)
        Me.dsp_CreatePreparation.TabIndex = 33
        Me.dsp_CreatePreparation.Text = "Preparation"
        Me.dsp_CreatePreparation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dsp_RcpCreatePrepPressureDropTime
        '
        Me.dsp_RcpCreatePrepPressureDropTime.Location = New System.Drawing.Point(17, 298)
        Me.dsp_RcpCreatePrepPressureDropTime.Name = "dsp_RcpCreatePrepPressureDropTime"
        Me.dsp_RcpCreatePrepPressureDropTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepPressureDropTime.TabIndex = 25
        Me.dsp_RcpCreatePrepPressureDropTime.Text = "Pressure Drop Time" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(s) :"
        Me.dsp_RcpCreatePrepPressureDropTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreatePrepPressureDrop
        '
        Me.dsp_RcpCreatePrepPressureDrop.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpCreatePrepPressureDrop.Name = "dsp_RcpCreatePrepPressureDrop"
        Me.dsp_RcpCreatePrepPressureDrop.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepPressureDrop.TabIndex = 25
        Me.dsp_RcpCreatePrepPressureDrop.Text = "Pressure Drop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa) :"
        Me.dsp_RcpCreatePrepPressureDrop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 40)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Prep Fill Time (s) :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreatePrepPressure
        '
        Me.dsp_RcpCreatePrepPressure.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpCreatePrepPressure.Name = "dsp_RcpCreatePrepPressure"
        Me.dsp_RcpCreatePrepPressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepPressure.TabIndex = 26
        Me.dsp_RcpCreatePrepPressure.Text = "Back Pressure" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(kPa) :"
        Me.dsp_RcpCreatePrepPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreatePrepFlow
        '
        Me.dsp_RcpCreatePrepFlow.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpCreatePrepFlow.Name = "dsp_RcpCreatePrepFlow"
        Me.dsp_RcpCreatePrepFlow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepFlow.TabIndex = 26
        Me.dsp_RcpCreatePrepFlow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpCreatePrepFlow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreatePrepBleed
        '
        Me.dsp_RcpCreatePrepBleed.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpCreatePrepBleed.Name = "dsp_RcpCreatePrepBleed"
        Me.dsp_RcpCreatePrepBleed.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepBleed.TabIndex = 27
        Me.dsp_RcpCreatePrepBleed.Text = "Prep Air Bleed Time" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(s) :"
        Me.dsp_RcpCreatePrepBleed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreatePrepFill
        '
        Me.dsp_RcpCreatePrepFill.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpCreatePrepFill.Name = "dsp_RcpCreatePrepFill"
        Me.dsp_RcpCreatePrepFill.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreatePrepFill.TabIndex = 28
        Me.dsp_RcpCreatePrepFill.Text = "Prep Fill Time (s) :"
        Me.dsp_RcpCreatePrepFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreatePrepPressureDropTime
        '
        Me.txtbx_RcpCreatePrepPressureDropTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepPressureDropTime.Location = New System.Drawing.Point(183, 306)
        Me.txtbx_RcpCreatePrepPressureDropTime.MaxLength = 3
        Me.txtbx_RcpCreatePrepPressureDropTime.Name = "txtbx_RcpCreatePrepPressureDropTime"
        Me.txtbx_RcpCreatePrepPressureDropTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepPressureDropTime.TabIndex = 29
        '
        'txtbx_RcpCreatePrepPressureDrop
        '
        Me.txtbx_RcpCreatePrepPressureDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepPressureDrop.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpCreatePrepPressureDrop.MaxLength = 3
        Me.txtbx_RcpCreatePrepPressureDrop.Name = "txtbx_RcpCreatePrepPressureDrop"
        Me.txtbx_RcpCreatePrepPressureDrop.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepPressureDrop.TabIndex = 30
        '
        'txtbx_RcpCreatePrepPressure
        '
        Me.txtbx_RcpCreatePrepPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepPressure.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpCreatePrepPressure.MaxLength = 3
        Me.txtbx_RcpCreatePrepPressure.Name = "txtbx_RcpCreatePrepPressure"
        Me.txtbx_RcpCreatePrepPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepPressure.TabIndex = 30
        '
        'txtbx_RcpCreatePrepFlow
        '
        Me.txtbx_RcpCreatePrepFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepFlow.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpCreatePrepFlow.MaxLength = 3
        Me.txtbx_RcpCreatePrepFlow.Name = "txtbx_RcpCreatePrepFlow"
        Me.txtbx_RcpCreatePrepFlow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepFlow.TabIndex = 30
        '
        'txtbx_RcpCreatePrepBleed
        '
        Me.txtbx_RcpCreatePrepBleed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepBleed.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpCreatePrepBleed.MaxLength = 3
        Me.txtbx_RcpCreatePrepBleed.Name = "txtbx_RcpCreatePrepBleed"
        Me.txtbx_RcpCreatePrepBleed.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepBleed.TabIndex = 31
        '
        'txtbx_RcpCreatePrepFill
        '
        Me.txtbx_RcpCreatePrepFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreatePrepFill.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpCreatePrepFill.MaxLength = 3
        Me.txtbx_RcpCreatePrepFill.Name = "txtbx_RcpCreatePrepFill"
        Me.txtbx_RcpCreatePrepFill.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreatePrepFill.TabIndex = 32
        '
        'panel_RcpCreateDrain3
        '
        Me.panel_RcpCreateDrain3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpCreateDrain3.Controls.Add(Me.txtbx_RcpCreateDrain3Time)
        Me.panel_RcpCreateDrain3.Controls.Add(Me.dsp_RcpCreateDrain3Time)
        Me.panel_RcpCreateDrain3.Controls.Add(Me.txtbx_RcpCreateDrain3Pressure)
        Me.panel_RcpCreateDrain3.Controls.Add(Me.dsp_RcpCreateDrain3Pressure)
        Me.panel_RcpCreateDrain3.Controls.Add(Me.checkbx_CreateDrain3)
        Me.panel_RcpCreateDrain3.Location = New System.Drawing.Point(1548, 491)
        Me.panel_RcpCreateDrain3.Name = "panel_RcpCreateDrain3"
        Me.panel_RcpCreateDrain3.Size = New System.Drawing.Size(307, 172)
        Me.panel_RcpCreateDrain3.TabIndex = 18
        '
        'txtbx_RcpCreateDrain3Time
        '
        Me.txtbx_RcpCreateDrain3Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDrain3Time.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpCreateDrain3Time.MaxLength = 3
        Me.txtbx_RcpCreateDrain3Time.Name = "txtbx_RcpCreateDrain3Time"
        Me.txtbx_RcpCreateDrain3Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDrain3Time.TabIndex = 15
        '
        'dsp_RcpCreateDrain3Time
        '
        Me.dsp_RcpCreateDrain3Time.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpCreateDrain3Time.Name = "dsp_RcpCreateDrain3Time"
        Me.dsp_RcpCreateDrain3Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDrain3Time.TabIndex = 14
        Me.dsp_RcpCreateDrain3Time.Text = "Drain-3 Time :"
        Me.dsp_RcpCreateDrain3Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDrain3Pressure
        '
        Me.txtbx_RcpCreateDrain3Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDrain3Pressure.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpCreateDrain3Pressure.MaxLength = 4
        Me.txtbx_RcpCreateDrain3Pressure.Name = "txtbx_RcpCreateDrain3Pressure"
        Me.txtbx_RcpCreateDrain3Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDrain3Pressure.TabIndex = 11
        '
        'dsp_RcpCreateDrain3Pressure
        '
        Me.dsp_RcpCreateDrain3Pressure.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpCreateDrain3Pressure.Name = "dsp_RcpCreateDrain3Pressure"
        Me.dsp_RcpCreateDrain3Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDrain3Pressure.TabIndex = 10
        Me.dsp_RcpCreateDrain3Pressure.Text = "Drain-3 N2 Purge Pressure (kPa) :"
        Me.dsp_RcpCreateDrain3Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkbx_CreateDrain3
        '
        Me.checkbx_CreateDrain3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_CreateDrain3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_CreateDrain3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.checkbx_CreateDrain3.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_CreateDrain3.Name = "checkbx_CreateDrain3"
        Me.checkbx_CreateDrain3.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_CreateDrain3.TabIndex = 7
        Me.checkbx_CreateDrain3.Text = "Drain-3 Enable"
        Me.checkbx_CreateDrain3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_CreateDrain3.UseVisualStyleBackColor = True
        '
        'panel_RcpCreateDrain2
        '
        Me.panel_RcpCreateDrain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpCreateDrain2.Controls.Add(Me.txtbx_RcpCreateDrain2Time)
        Me.panel_RcpCreateDrain2.Controls.Add(Me.dsp_RcpCreateDrain2Time)
        Me.panel_RcpCreateDrain2.Controls.Add(Me.txtbx_RcpCreateDrain2Pressure)
        Me.panel_RcpCreateDrain2.Controls.Add(Me.dsp_RcpCreateDrain2Pressure)
        Me.panel_RcpCreateDrain2.Controls.Add(Me.checkbx_CreateDrain2)
        Me.panel_RcpCreateDrain2.Location = New System.Drawing.Point(1549, 313)
        Me.panel_RcpCreateDrain2.Name = "panel_RcpCreateDrain2"
        Me.panel_RcpCreateDrain2.Size = New System.Drawing.Size(307, 172)
        Me.panel_RcpCreateDrain2.TabIndex = 18
        '
        'txtbx_RcpCreateDrain2Time
        '
        Me.txtbx_RcpCreateDrain2Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDrain2Time.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpCreateDrain2Time.MaxLength = 3
        Me.txtbx_RcpCreateDrain2Time.Name = "txtbx_RcpCreateDrain2Time"
        Me.txtbx_RcpCreateDrain2Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDrain2Time.TabIndex = 15
        '
        'dsp_RcpCreateDrain2Time
        '
        Me.dsp_RcpCreateDrain2Time.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpCreateDrain2Time.Name = "dsp_RcpCreateDrain2Time"
        Me.dsp_RcpCreateDrain2Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDrain2Time.TabIndex = 14
        Me.dsp_RcpCreateDrain2Time.Text = "Drain-2 Time :"
        Me.dsp_RcpCreateDrain2Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDrain2Pressure
        '
        Me.txtbx_RcpCreateDrain2Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDrain2Pressure.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpCreateDrain2Pressure.MaxLength = 4
        Me.txtbx_RcpCreateDrain2Pressure.Name = "txtbx_RcpCreateDrain2Pressure"
        Me.txtbx_RcpCreateDrain2Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDrain2Pressure.TabIndex = 11
        '
        'dsp_RcpCreateDrain2Pressure
        '
        Me.dsp_RcpCreateDrain2Pressure.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpCreateDrain2Pressure.Name = "dsp_RcpCreateDrain2Pressure"
        Me.dsp_RcpCreateDrain2Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDrain2Pressure.TabIndex = 10
        Me.dsp_RcpCreateDrain2Pressure.Text = "Drain-2 N2 Purge Pressure (kPa) :"
        Me.dsp_RcpCreateDrain2Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkbx_CreateDrain2
        '
        Me.checkbx_CreateDrain2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_CreateDrain2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_CreateDrain2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.checkbx_CreateDrain2.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_CreateDrain2.Name = "checkbx_CreateDrain2"
        Me.checkbx_CreateDrain2.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_CreateDrain2.TabIndex = 7
        Me.checkbx_CreateDrain2.Text = "Drain-2 Enable"
        Me.checkbx_CreateDrain2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_CreateDrain2.UseVisualStyleBackColor = True
        '
        'panel_RcpCreateFlush2
        '
        Me.panel_RcpCreateFlush2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpCreateFlush2.Controls.Add(Me.txtbx_RcpCreateFlush2Time)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.dsp_RcpCreateFlush2Time)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.txtbx_RcpCreateFlush2Stabilize)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.dsp_RcpCreateFlush2Stabilize)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.txtbx_RcpCreateFlush2Pressure)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.dsp_RcpCreateFlush2Pressure)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.txtbx_RcpCreateFlush2FlowTol)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.dsp_RcpCreateFlush2FlowTol)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.txtbx_RcpCreateFlush2Flow)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.checkbx_CreateFlush2)
        Me.panel_RcpCreateFlush2.Controls.Add(Me.dsp_RcpCreateFlush2Flow)
        Me.panel_RcpCreateFlush2.Location = New System.Drawing.Point(900, 451)
        Me.panel_RcpCreateFlush2.Name = "panel_RcpCreateFlush2"
        Me.panel_RcpCreateFlush2.Size = New System.Drawing.Size(307, 310)
        Me.panel_RcpCreateFlush2.TabIndex = 17
        '
        'txtbx_RcpCreateFlush2Time
        '
        Me.txtbx_RcpCreateFlush2Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush2Time.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpCreateFlush2Time.MaxLength = 3
        Me.txtbx_RcpCreateFlush2Time.Name = "txtbx_RcpCreateFlush2Time"
        Me.txtbx_RcpCreateFlush2Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush2Time.TabIndex = 15
        '
        'dsp_RcpCreateFlush2Time
        '
        Me.dsp_RcpCreateFlush2Time.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpCreateFlush2Time.Name = "dsp_RcpCreateFlush2Time"
        Me.dsp_RcpCreateFlush2Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush2Time.TabIndex = 14
        Me.dsp_RcpCreateFlush2Time.Text = "Flush-2 Time (s) :"
        Me.dsp_RcpCreateFlush2Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush2Stabilize
        '
        Me.txtbx_RcpCreateFlush2Stabilize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush2Stabilize.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpCreateFlush2Stabilize.MaxLength = 3
        Me.txtbx_RcpCreateFlush2Stabilize.Name = "txtbx_RcpCreateFlush2Stabilize"
        Me.txtbx_RcpCreateFlush2Stabilize.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush2Stabilize.TabIndex = 13
        '
        'dsp_RcpCreateFlush2Stabilize
        '
        Me.dsp_RcpCreateFlush2Stabilize.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpCreateFlush2Stabilize.Name = "dsp_RcpCreateFlush2Stabilize"
        Me.dsp_RcpCreateFlush2Stabilize.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush2Stabilize.TabIndex = 12
        Me.dsp_RcpCreateFlush2Stabilize.Text = "Flush-2 Stabilize Time (s) :"
        Me.dsp_RcpCreateFlush2Stabilize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush2Pressure
        '
        Me.txtbx_RcpCreateFlush2Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush2Pressure.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpCreateFlush2Pressure.MaxLength = 5
        Me.txtbx_RcpCreateFlush2Pressure.Name = "txtbx_RcpCreateFlush2Pressure"
        Me.txtbx_RcpCreateFlush2Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush2Pressure.TabIndex = 11
        '
        'dsp_RcpCreateFlush2Pressure
        '
        Me.dsp_RcpCreateFlush2Pressure.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpCreateFlush2Pressure.Name = "dsp_RcpCreateFlush2Pressure"
        Me.dsp_RcpCreateFlush2Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush2Pressure.TabIndex = 10
        Me.dsp_RcpCreateFlush2Pressure.Text = "Back Pressure (kPa) :"
        Me.dsp_RcpCreateFlush2Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush2FlowTol
        '
        Me.txtbx_RcpCreateFlush2FlowTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush2FlowTol.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpCreateFlush2FlowTol.MaxLength = 3
        Me.txtbx_RcpCreateFlush2FlowTol.Name = "txtbx_RcpCreateFlush2FlowTol"
        Me.txtbx_RcpCreateFlush2FlowTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush2FlowTol.TabIndex = 9
        '
        'dsp_RcpCreateFlush2FlowTol
        '
        Me.dsp_RcpCreateFlush2FlowTol.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpCreateFlush2FlowTol.Name = "dsp_RcpCreateFlush2FlowTol"
        Me.dsp_RcpCreateFlush2FlowTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush2FlowTol.TabIndex = 8
        Me.dsp_RcpCreateFlush2FlowTol.Text = "Flowrate Tolerance (l/min) (+/-) :"
        Me.dsp_RcpCreateFlush2FlowTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush2Flow
        '
        Me.txtbx_RcpCreateFlush2Flow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush2Flow.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpCreateFlush2Flow.MaxLength = 4
        Me.txtbx_RcpCreateFlush2Flow.Name = "txtbx_RcpCreateFlush2Flow"
        Me.txtbx_RcpCreateFlush2Flow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush2Flow.TabIndex = 7
        '
        'checkbx_CreateFlush2
        '
        Me.checkbx_CreateFlush2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_CreateFlush2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_CreateFlush2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.checkbx_CreateFlush2.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_CreateFlush2.Name = "checkbx_CreateFlush2"
        Me.checkbx_CreateFlush2.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_CreateFlush2.TabIndex = 7
        Me.checkbx_CreateFlush2.Text = "Flush-2 Enable"
        Me.checkbx_CreateFlush2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_CreateFlush2.UseVisualStyleBackColor = True
        '
        'dsp_RcpCreateFlush2Flow
        '
        Me.dsp_RcpCreateFlush2Flow.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpCreateFlush2Flow.Name = "dsp_RcpCreateFlush2Flow"
        Me.dsp_RcpCreateFlush2Flow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush2Flow.TabIndex = 6
        Me.dsp_RcpCreateFlush2Flow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpCreateFlush2Flow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.txtbx_RcpCreateVerTol)
        Me.Panel8.Controls.Add(Me.dsp_RcpCreateVerTol)
        Me.Panel8.Location = New System.Drawing.Point(575, 45)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1280, 80)
        Me.Panel8.TabIndex = 24
        '
        'txtbx_RcpCreateVerTol
        '
        Me.txtbx_RcpCreateVerTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateVerTol.Location = New System.Drawing.Point(183, 30)
        Me.txtbx_RcpCreateVerTol.MaxLength = 3
        Me.txtbx_RcpCreateVerTol.Name = "txtbx_RcpCreateVerTol"
        Me.txtbx_RcpCreateVerTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateVerTol.TabIndex = 7
        '
        'dsp_RcpCreateVerTol
        '
        Me.dsp_RcpCreateVerTol.Location = New System.Drawing.Point(17, 20)
        Me.dsp_RcpCreateVerTol.Name = "dsp_RcpCreateVerTol"
        Me.dsp_RcpCreateVerTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateVerTol.TabIndex = 6
        Me.dsp_RcpCreateVerTol.Text = "Verification Tolerance (kPa) (+/-) :"
        Me.dsp_RcpCreateVerTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_RcpCreateDrain1
        '
        Me.panel_RcpCreateDrain1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpCreateDrain1.Controls.Add(Me.txtbx_RcpCreateDrain1Time)
        Me.panel_RcpCreateDrain1.Controls.Add(Me.dsp_RcpCreateDrain1Time)
        Me.panel_RcpCreateDrain1.Controls.Add(Me.txtbx_RcpCreateDrain1Pressure)
        Me.panel_RcpCreateDrain1.Controls.Add(Me.dsp_RcpCreateDrain1Pressure)
        Me.panel_RcpCreateDrain1.Controls.Add(Me.checkbx_CreateDrain1)
        Me.panel_RcpCreateDrain1.Location = New System.Drawing.Point(1548, 135)
        Me.panel_RcpCreateDrain1.Name = "panel_RcpCreateDrain1"
        Me.panel_RcpCreateDrain1.Size = New System.Drawing.Size(307, 172)
        Me.panel_RcpCreateDrain1.TabIndex = 17
        '
        'txtbx_RcpCreateDrain1Time
        '
        Me.txtbx_RcpCreateDrain1Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDrain1Time.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpCreateDrain1Time.MaxLength = 3
        Me.txtbx_RcpCreateDrain1Time.Name = "txtbx_RcpCreateDrain1Time"
        Me.txtbx_RcpCreateDrain1Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDrain1Time.TabIndex = 15
        '
        'dsp_RcpCreateDrain1Time
        '
        Me.dsp_RcpCreateDrain1Time.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpCreateDrain1Time.Name = "dsp_RcpCreateDrain1Time"
        Me.dsp_RcpCreateDrain1Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDrain1Time.TabIndex = 14
        Me.dsp_RcpCreateDrain1Time.Text = "Drain-1 Time :"
        Me.dsp_RcpCreateDrain1Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDrain1Pressure
        '
        Me.txtbx_RcpCreateDrain1Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDrain1Pressure.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpCreateDrain1Pressure.MaxLength = 4
        Me.txtbx_RcpCreateDrain1Pressure.Name = "txtbx_RcpCreateDrain1Pressure"
        Me.txtbx_RcpCreateDrain1Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDrain1Pressure.TabIndex = 11
        '
        'dsp_RcpCreateDrain1Pressure
        '
        Me.dsp_RcpCreateDrain1Pressure.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpCreateDrain1Pressure.Name = "dsp_RcpCreateDrain1Pressure"
        Me.dsp_RcpCreateDrain1Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDrain1Pressure.TabIndex = 10
        Me.dsp_RcpCreateDrain1Pressure.Text = "Drain-1 N2 Purge Pressure (kPa) :"
        Me.dsp_RcpCreateDrain1Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkbx_CreateDrain1
        '
        Me.checkbx_CreateDrain1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_CreateDrain1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_CreateDrain1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.checkbx_CreateDrain1.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_CreateDrain1.Name = "checkbx_CreateDrain1"
        Me.checkbx_CreateDrain1.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_CreateDrain1.TabIndex = 7
        Me.checkbx_CreateDrain1.Text = "Drain-1 Enable"
        Me.checkbx_CreateDrain1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_CreateDrain1.UseVisualStyleBackColor = True
        '
        'panel_RcpCreateDPTest1
        '
        Me.panel_RcpCreateDPTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.checkbx_CreateDPTest2)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.checkbx_CreateDPTest1)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPPoints)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPPoints)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPUpLimit)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPUpLimit)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPLowLimit)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPFlow)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPLowLimit)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPTime)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPTime)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPStabilize)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPStabilize)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPPressure)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPPressure)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPFlowTol)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.dsp_RcpCreateDPFlowTol)
        Me.panel_RcpCreateDPTest1.Controls.Add(Me.txtbx_RcpCreateDPFlow)
        Me.panel_RcpCreateDPTest1.Location = New System.Drawing.Point(1224, 135)
        Me.panel_RcpCreateDPTest1.Name = "panel_RcpCreateDPTest1"
        Me.panel_RcpCreateDPTest1.Size = New System.Drawing.Size(307, 528)
        Me.panel_RcpCreateDPTest1.TabIndex = 17
        '
        'checkbx_CreateDPTest2
        '
        Me.checkbx_CreateDPTest2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_CreateDPTest2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_CreateDPTest2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.checkbx_CreateDPTest2.Location = New System.Drawing.Point(49, 58)
        Me.checkbx_CreateDPTest2.Name = "checkbx_CreateDPTest2"
        Me.checkbx_CreateDPTest2.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_CreateDPTest2.TabIndex = 7
        Me.checkbx_CreateDPTest2.Text = "DP Test-2 Enable"
        Me.checkbx_CreateDPTest2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_CreateDPTest2.UseVisualStyleBackColor = True
        '
        'checkbx_CreateDPTest1
        '
        Me.checkbx_CreateDPTest1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_CreateDPTest1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_CreateDPTest1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.checkbx_CreateDPTest1.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_CreateDPTest1.Name = "checkbx_CreateDPTest1"
        Me.checkbx_CreateDPTest1.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_CreateDPTest1.TabIndex = 7
        Me.checkbx_CreateDPTest1.Text = "DP Test-1 Enable"
        Me.checkbx_CreateDPTest1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_CreateDPTest1.UseVisualStyleBackColor = True
        '
        'txtbx_RcpCreateDPPoints
        '
        Me.txtbx_RcpCreateDPPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPPoints.Location = New System.Drawing.Point(183, 450)
        Me.txtbx_RcpCreateDPPoints.MaxLength = 2
        Me.txtbx_RcpCreateDPPoints.Name = "txtbx_RcpCreateDPPoints"
        Me.txtbx_RcpCreateDPPoints.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPPoints.TabIndex = 21
        '
        'dsp_RcpCreateDPPoints
        '
        Me.dsp_RcpCreateDPPoints.Location = New System.Drawing.Point(17, 442)
        Me.dsp_RcpCreateDPPoints.Name = "dsp_RcpCreateDPPoints"
        Me.dsp_RcpCreateDPPoints.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPPoints.TabIndex = 20
        Me.dsp_RcpCreateDPPoints.Text = "Number of Test Points :"
        Me.dsp_RcpCreateDPPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDPUpLimit
        '
        Me.txtbx_RcpCreateDPUpLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPUpLimit.Location = New System.Drawing.Point(183, 402)
        Me.txtbx_RcpCreateDPUpLimit.MaxLength = 5
        Me.txtbx_RcpCreateDPUpLimit.Name = "txtbx_RcpCreateDPUpLimit"
        Me.txtbx_RcpCreateDPUpLimit.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPUpLimit.TabIndex = 19
        '
        'dsp_RcpCreateDPUpLimit
        '
        Me.dsp_RcpCreateDPUpLimit.Location = New System.Drawing.Point(17, 394)
        Me.dsp_RcpCreateDPUpLimit.Name = "dsp_RcpCreateDPUpLimit"
        Me.dsp_RcpCreateDPUpLimit.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPUpLimit.TabIndex = 18
        Me.dsp_RcpCreateDPUpLimit.Text = "DP Upper Limit (kPa) :"
        Me.dsp_RcpCreateDPUpLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDPLowLimit
        '
        Me.txtbx_RcpCreateDPLowLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPLowLimit.Location = New System.Drawing.Point(183, 354)
        Me.txtbx_RcpCreateDPLowLimit.MaxLength = 5
        Me.txtbx_RcpCreateDPLowLimit.Name = "txtbx_RcpCreateDPLowLimit"
        Me.txtbx_RcpCreateDPLowLimit.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPLowLimit.TabIndex = 17
        '
        'dsp_RcpCreateDPFlow
        '
        Me.dsp_RcpCreateDPFlow.Location = New System.Drawing.Point(17, 108)
        Me.dsp_RcpCreateDPFlow.Name = "dsp_RcpCreateDPFlow"
        Me.dsp_RcpCreateDPFlow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPFlow.TabIndex = 6
        Me.dsp_RcpCreateDPFlow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpCreateDPFlow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreateDPLowLimit
        '
        Me.dsp_RcpCreateDPLowLimit.Location = New System.Drawing.Point(17, 346)
        Me.dsp_RcpCreateDPLowLimit.Name = "dsp_RcpCreateDPLowLimit"
        Me.dsp_RcpCreateDPLowLimit.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPLowLimit.TabIndex = 16
        Me.dsp_RcpCreateDPLowLimit.Text = "DP Lower Limit (kPa)  :"
        Me.dsp_RcpCreateDPLowLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDPTime
        '
        Me.txtbx_RcpCreateDPTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPTime.Location = New System.Drawing.Point(183, 306)
        Me.txtbx_RcpCreateDPTime.MaxLength = 3
        Me.txtbx_RcpCreateDPTime.Name = "txtbx_RcpCreateDPTime"
        Me.txtbx_RcpCreateDPTime.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPTime.TabIndex = 15
        '
        'dsp_RcpCreateDPTime
        '
        Me.dsp_RcpCreateDPTime.Location = New System.Drawing.Point(17, 298)
        Me.dsp_RcpCreateDPTime.Name = "dsp_RcpCreateDPTime"
        Me.dsp_RcpCreateDPTime.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPTime.TabIndex = 14
        Me.dsp_RcpCreateDPTime.Text = "DP Time (s) :"
        Me.dsp_RcpCreateDPTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDPStabilize
        '
        Me.txtbx_RcpCreateDPStabilize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPStabilize.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpCreateDPStabilize.MaxLength = 3
        Me.txtbx_RcpCreateDPStabilize.Name = "txtbx_RcpCreateDPStabilize"
        Me.txtbx_RcpCreateDPStabilize.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPStabilize.TabIndex = 13
        '
        'dsp_RcpCreateDPStabilize
        '
        Me.dsp_RcpCreateDPStabilize.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpCreateDPStabilize.Name = "dsp_RcpCreateDPStabilize"
        Me.dsp_RcpCreateDPStabilize.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPStabilize.TabIndex = 12
        Me.dsp_RcpCreateDPStabilize.Text = "DP Stabilize Time (s) :"
        Me.dsp_RcpCreateDPStabilize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDPPressure
        '
        Me.txtbx_RcpCreateDPPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPPressure.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpCreateDPPressure.MaxLength = 5
        Me.txtbx_RcpCreateDPPressure.Name = "txtbx_RcpCreateDPPressure"
        Me.txtbx_RcpCreateDPPressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPPressure.TabIndex = 11
        '
        'dsp_RcpCreateDPPressure
        '
        Me.dsp_RcpCreateDPPressure.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpCreateDPPressure.Name = "dsp_RcpCreateDPPressure"
        Me.dsp_RcpCreateDPPressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPPressure.TabIndex = 10
        Me.dsp_RcpCreateDPPressure.Text = "Back Pressure (kPa) :"
        Me.dsp_RcpCreateDPPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDPFlowTol
        '
        Me.txtbx_RcpCreateDPFlowTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPFlowTol.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpCreateDPFlowTol.MaxLength = 3
        Me.txtbx_RcpCreateDPFlowTol.Name = "txtbx_RcpCreateDPFlowTol"
        Me.txtbx_RcpCreateDPFlowTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPFlowTol.TabIndex = 9
        '
        'dsp_RcpCreateDPFlowTol
        '
        Me.dsp_RcpCreateDPFlowTol.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpCreateDPFlowTol.Name = "dsp_RcpCreateDPFlowTol"
        Me.dsp_RcpCreateDPFlowTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateDPFlowTol.TabIndex = 8
        Me.dsp_RcpCreateDPFlowTol.Text = "Flowrate Tolerance (l/min) (+/-) :"
        Me.dsp_RcpCreateDPFlowTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateDPFlow
        '
        Me.txtbx_RcpCreateDPFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateDPFlow.Location = New System.Drawing.Point(183, 116)
        Me.txtbx_RcpCreateDPFlow.MaxLength = 4
        Me.txtbx_RcpCreateDPFlow.Name = "txtbx_RcpCreateDPFlow"
        Me.txtbx_RcpCreateDPFlow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateDPFlow.TabIndex = 7
        '
        'panel_RcpCreateFlush1
        '
        Me.panel_RcpCreateFlush1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RcpCreateFlush1.Controls.Add(Me.txtbx_RcpCreateFlush1Time)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.dsp_RcpCreateFlush1Time)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.txtbx_RcpCreateFlush1Stabilize)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.dsp_RcpCreateFlush1Stabilize)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.txtbx_RcpCreateFlush1Pressure)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.dsp_RcpCreateFlush1Pressure)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.txtbx_RcpCreateFlush1FlowTol)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.dsp_RcpCreateFlush1FlowTol)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.txtbx_RcpCreateFlush1Flow)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.checkbx_CreateFlush1)
        Me.panel_RcpCreateFlush1.Controls.Add(Me.dsp_RcpCreateFlush1Flow)
        Me.panel_RcpCreateFlush1.Location = New System.Drawing.Point(900, 135)
        Me.panel_RcpCreateFlush1.Name = "panel_RcpCreateFlush1"
        Me.panel_RcpCreateFlush1.Size = New System.Drawing.Size(307, 310)
        Me.panel_RcpCreateFlush1.TabIndex = 16
        '
        'txtbx_RcpCreateFlush1Time
        '
        Me.txtbx_RcpCreateFlush1Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush1Time.Location = New System.Drawing.Point(183, 258)
        Me.txtbx_RcpCreateFlush1Time.MaxLength = 3
        Me.txtbx_RcpCreateFlush1Time.Name = "txtbx_RcpCreateFlush1Time"
        Me.txtbx_RcpCreateFlush1Time.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush1Time.TabIndex = 15
        '
        'dsp_RcpCreateFlush1Time
        '
        Me.dsp_RcpCreateFlush1Time.Location = New System.Drawing.Point(17, 250)
        Me.dsp_RcpCreateFlush1Time.Name = "dsp_RcpCreateFlush1Time"
        Me.dsp_RcpCreateFlush1Time.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush1Time.TabIndex = 14
        Me.dsp_RcpCreateFlush1Time.Text = "Flush-1 Time (s) :"
        Me.dsp_RcpCreateFlush1Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush1Stabilize
        '
        Me.txtbx_RcpCreateFlush1Stabilize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush1Stabilize.Location = New System.Drawing.Point(183, 210)
        Me.txtbx_RcpCreateFlush1Stabilize.MaxLength = 3
        Me.txtbx_RcpCreateFlush1Stabilize.Name = "txtbx_RcpCreateFlush1Stabilize"
        Me.txtbx_RcpCreateFlush1Stabilize.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush1Stabilize.TabIndex = 13
        '
        'dsp_RcpCreateFlush1Stabilize
        '
        Me.dsp_RcpCreateFlush1Stabilize.Location = New System.Drawing.Point(17, 202)
        Me.dsp_RcpCreateFlush1Stabilize.Name = "dsp_RcpCreateFlush1Stabilize"
        Me.dsp_RcpCreateFlush1Stabilize.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush1Stabilize.TabIndex = 12
        Me.dsp_RcpCreateFlush1Stabilize.Text = "Flush-1 Stabilize Time (s) :"
        Me.dsp_RcpCreateFlush1Stabilize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush1Pressure
        '
        Me.txtbx_RcpCreateFlush1Pressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush1Pressure.Location = New System.Drawing.Point(183, 162)
        Me.txtbx_RcpCreateFlush1Pressure.MaxLength = 5
        Me.txtbx_RcpCreateFlush1Pressure.Name = "txtbx_RcpCreateFlush1Pressure"
        Me.txtbx_RcpCreateFlush1Pressure.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush1Pressure.TabIndex = 11
        '
        'dsp_RcpCreateFlush1Pressure
        '
        Me.dsp_RcpCreateFlush1Pressure.Location = New System.Drawing.Point(17, 154)
        Me.dsp_RcpCreateFlush1Pressure.Name = "dsp_RcpCreateFlush1Pressure"
        Me.dsp_RcpCreateFlush1Pressure.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush1Pressure.TabIndex = 10
        Me.dsp_RcpCreateFlush1Pressure.Text = "Back Pressure (kPa) :"
        Me.dsp_RcpCreateFlush1Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush1FlowTol
        '
        Me.txtbx_RcpCreateFlush1FlowTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush1FlowTol.Location = New System.Drawing.Point(183, 114)
        Me.txtbx_RcpCreateFlush1FlowTol.MaxLength = 3
        Me.txtbx_RcpCreateFlush1FlowTol.Name = "txtbx_RcpCreateFlush1FlowTol"
        Me.txtbx_RcpCreateFlush1FlowTol.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush1FlowTol.TabIndex = 9
        '
        'dsp_RcpCreateFlush1FlowTol
        '
        Me.dsp_RcpCreateFlush1FlowTol.Location = New System.Drawing.Point(17, 106)
        Me.dsp_RcpCreateFlush1FlowTol.Name = "dsp_RcpCreateFlush1FlowTol"
        Me.dsp_RcpCreateFlush1FlowTol.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush1FlowTol.TabIndex = 8
        Me.dsp_RcpCreateFlush1FlowTol.Text = "Flowrate Tolerance (l/min) (+/-) :"
        Me.dsp_RcpCreateFlush1FlowTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbx_RcpCreateFlush1Flow
        '
        Me.txtbx_RcpCreateFlush1Flow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbx_RcpCreateFlush1Flow.Location = New System.Drawing.Point(183, 66)
        Me.txtbx_RcpCreateFlush1Flow.MaxLength = 4
        Me.txtbx_RcpCreateFlush1Flow.Multiline = True
        Me.txtbx_RcpCreateFlush1Flow.Name = "txtbx_RcpCreateFlush1Flow"
        Me.txtbx_RcpCreateFlush1Flow.Size = New System.Drawing.Size(100, 25)
        Me.txtbx_RcpCreateFlush1Flow.TabIndex = 7
        '
        'checkbx_CreateFlush1
        '
        Me.checkbx_CreateFlush1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.checkbx_CreateFlush1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkbx_CreateFlush1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbx_CreateFlush1.Location = New System.Drawing.Point(49, 15)
        Me.checkbx_CreateFlush1.Name = "checkbx_CreateFlush1"
        Me.checkbx_CreateFlush1.Size = New System.Drawing.Size(200, 40)
        Me.checkbx_CreateFlush1.TabIndex = 7
        Me.checkbx_CreateFlush1.Text = "Flush-1 Enable"
        Me.checkbx_CreateFlush1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.checkbx_CreateFlush1.UseVisualStyleBackColor = True
        '
        'dsp_RcpCreateFlush1Flow
        '
        Me.dsp_RcpCreateFlush1Flow.Location = New System.Drawing.Point(17, 58)
        Me.dsp_RcpCreateFlush1Flow.Name = "dsp_RcpCreateFlush1Flow"
        Me.dsp_RcpCreateFlush1Flow.Size = New System.Drawing.Size(150, 40)
        Me.dsp_RcpCreateFlush1Flow.TabIndex = 6
        Me.dsp_RcpCreateFlush1Flow.Text = "Flowrate (l/min) :"
        Me.dsp_RcpCreateFlush1Flow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreateRcpParameters
        '
        Me.dsp_RcpCreateRcpParameters.AutoSize = True
        Me.dsp_RcpCreateRcpParameters.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpCreateRcpParameters.Location = New System.Drawing.Point(1154, 4)
        Me.dsp_RcpCreateRcpParameters.Name = "dsp_RcpCreateRcpParameters"
        Me.dsp_RcpCreateRcpParameters.Size = New System.Drawing.Size(188, 30)
        Me.dsp_RcpCreateRcpParameters.TabIndex = 4
        Me.dsp_RcpCreateRcpParameters.Text = "Recipe Parameters"
        Me.dsp_RcpCreateRcpParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel_Create
        '
        Me.panel_Create.Controls.Add(Me.Panel6)
        Me.panel_Create.Controls.Add(Me.panel_RecipeGeneration)
        Me.panel_Create.Controls.Add(Me.panel_ProdSKUCreation)
        Me.panel_Create.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel_Create.Location = New System.Drawing.Point(0, 0)
        Me.panel_Create.Name = "panel_Create"
        Me.panel_Create.Size = New System.Drawing.Size(562, 767)
        Me.panel_Create.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.TextBox1)
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.ComboBox5)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Location = New System.Drawing.Point(3, 486)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(556, 200)
        Me.Panel6.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(152, 113)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(250, 29)
        Me.TextBox1.TabIndex = 105
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Window
        Me.Button2.Location = New System.Drawing.Point(420, 75)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 60)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Create"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(554, 50)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Changeover Part Creation"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"Fittings", "Blanks"})
        Me.ComboBox5.Location = New System.Drawing.Point(152, 68)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(250, 29)
        Me.ComboBox5.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 25)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "ID :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 25)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Fitting Type :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_RecipeGeneration
        '
        Me.panel_RecipeGeneration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_RecipeGeneration.Controls.Add(Me.dsp_RcpCreation)
        Me.panel_RecipeGeneration.Controls.Add(Me.txtbx_RcpCreateRecipeID)
        Me.panel_RecipeGeneration.Controls.Add(Me.cmbx_RcpCreateType)
        Me.panel_RecipeGeneration.Controls.Add(Me.btn_RecipeIDCreate)
        Me.panel_RecipeGeneration.Controls.Add(Me.cmbx_RcpCreateFilterType)
        Me.panel_RecipeGeneration.Controls.Add(Me.dsp_RcpCreateType)
        Me.panel_RecipeGeneration.Controls.Add(Me.cmbx_RcpCreatePartID)
        Me.panel_RecipeGeneration.Controls.Add(Me.dsp_RcpCreatePart)
        Me.panel_RecipeGeneration.Controls.Add(Me.dsp_RcpCreateRecipeID)
        Me.panel_RecipeGeneration.Controls.Add(Me.dsp_RcpCreateFilter)
        Me.panel_RecipeGeneration.Location = New System.Drawing.Point(3, 227)
        Me.panel_RecipeGeneration.Name = "panel_RecipeGeneration"
        Me.panel_RecipeGeneration.Size = New System.Drawing.Size(556, 255)
        Me.panel_RecipeGeneration.TabIndex = 3
        '
        'dsp_RcpCreation
        '
        Me.dsp_RcpCreation.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpCreation.Location = New System.Drawing.Point(0, 0)
        Me.dsp_RcpCreation.Name = "dsp_RcpCreation"
        Me.dsp_RcpCreation.Size = New System.Drawing.Size(554, 50)
        Me.dsp_RcpCreation.TabIndex = 105
        Me.dsp_RcpCreation.Text = "Recipe Creation"
        Me.dsp_RcpCreation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbx_RcpCreateRecipeID
        '
        Me.txtbx_RcpCreateRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_RcpCreateRecipeID.Location = New System.Drawing.Point(152, 192)
        Me.txtbx_RcpCreateRecipeID.MaxLength = 20
        Me.txtbx_RcpCreateRecipeID.Name = "txtbx_RcpCreateRecipeID"
        Me.txtbx_RcpCreateRecipeID.Size = New System.Drawing.Size(250, 29)
        Me.txtbx_RcpCreateRecipeID.TabIndex = 21
        '
        'cmbx_RcpCreateType
        '
        Me.cmbx_RcpCreateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpCreateType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpCreateType.FormattingEnabled = True
        Me.cmbx_RcpCreateType.Location = New System.Drawing.Point(152, 147)
        Me.cmbx_RcpCreateType.Name = "cmbx_RcpCreateType"
        Me.cmbx_RcpCreateType.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpCreateType.TabIndex = 20
        '
        'btn_RecipeIDCreate
        '
        Me.btn_RecipeIDCreate.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_RecipeIDCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_RecipeIDCreate.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecipeIDCreate.ForeColor = System.Drawing.SystemColors.Window
        Me.btn_RecipeIDCreate.Location = New System.Drawing.Point(423, 86)
        Me.btn_RecipeIDCreate.Name = "btn_RecipeIDCreate"
        Me.btn_RecipeIDCreate.Size = New System.Drawing.Size(110, 60)
        Me.btn_RecipeIDCreate.TabIndex = 22
        Me.btn_RecipeIDCreate.Text = "Create"
        Me.btn_RecipeIDCreate.UseVisualStyleBackColor = False
        '
        'cmbx_RcpCreateFilterType
        '
        Me.cmbx_RcpCreateFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpCreateFilterType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpCreateFilterType.FormattingEnabled = True
        Me.cmbx_RcpCreateFilterType.Location = New System.Drawing.Point(152, 57)
        Me.cmbx_RcpCreateFilterType.Name = "cmbx_RcpCreateFilterType"
        Me.cmbx_RcpCreateFilterType.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpCreateFilterType.TabIndex = 17
        '
        'dsp_RcpCreateType
        '
        Me.dsp_RcpCreateType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpCreateType.Location = New System.Drawing.Point(21, 148)
        Me.dsp_RcpCreateType.Name = "dsp_RcpCreateType"
        Me.dsp_RcpCreateType.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpCreateType.TabIndex = 104
        Me.dsp_RcpCreateType.Text = "Type :"
        Me.dsp_RcpCreateType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbx_RcpCreatePartID
        '
        Me.cmbx_RcpCreatePartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_RcpCreatePartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_RcpCreatePartID.FormattingEnabled = True
        Me.cmbx_RcpCreatePartID.Location = New System.Drawing.Point(152, 102)
        Me.cmbx_RcpCreatePartID.Name = "cmbx_RcpCreatePartID"
        Me.cmbx_RcpCreatePartID.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_RcpCreatePartID.TabIndex = 18
        '
        'dsp_RcpCreatePart
        '
        Me.dsp_RcpCreatePart.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpCreatePart.Location = New System.Drawing.Point(21, 103)
        Me.dsp_RcpCreatePart.Name = "dsp_RcpCreatePart"
        Me.dsp_RcpCreatePart.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpCreatePart.TabIndex = 104
        Me.dsp_RcpCreatePart.Text = "Part ID :"
        Me.dsp_RcpCreatePart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreateRecipeID
        '
        Me.dsp_RcpCreateRecipeID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpCreateRecipeID.Location = New System.Drawing.Point(21, 193)
        Me.dsp_RcpCreateRecipeID.Name = "dsp_RcpCreateRecipeID"
        Me.dsp_RcpCreateRecipeID.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpCreateRecipeID.TabIndex = 104
        Me.dsp_RcpCreateRecipeID.Text = "Recipe ID :"
        Me.dsp_RcpCreateRecipeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_RcpCreateFilter
        '
        Me.dsp_RcpCreateFilter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_RcpCreateFilter.Location = New System.Drawing.Point(21, 57)
        Me.dsp_RcpCreateFilter.Name = "dsp_RcpCreateFilter"
        Me.dsp_RcpCreateFilter.Size = New System.Drawing.Size(125, 25)
        Me.dsp_RcpCreateFilter.TabIndex = 104
        Me.dsp_RcpCreateFilter.Text = "Filter Type :"
        Me.dsp_RcpCreateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_ProdSKUCreation
        '
        Me.panel_ProdSKUCreation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_ProdSKUCreation.Controls.Add(Me.cmbx_PartCreateJigType)
        Me.panel_ProdSKUCreation.Controls.Add(Me.txtbx_PartCreatePartID)
        Me.panel_ProdSKUCreation.Controls.Add(Me.btnPartIDCreate)
        Me.panel_ProdSKUCreation.Controls.Add(Me.dsp_PartIDCreation)
        Me.panel_ProdSKUCreation.Controls.Add(Me.cmbx_PartCreateFilterType)
        Me.panel_ProdSKUCreation.Controls.Add(Me.dsp_PartCreatePartID)
        Me.panel_ProdSKUCreation.Controls.Add(Me.dsp_PartCreateFiltertype)
        Me.panel_ProdSKUCreation.Controls.Add(Me.dsp_PartCreateJigType)
        Me.panel_ProdSKUCreation.Location = New System.Drawing.Point(3, 3)
        Me.panel_ProdSKUCreation.Name = "panel_ProdSKUCreation"
        Me.panel_ProdSKUCreation.Size = New System.Drawing.Size(556, 220)
        Me.panel_ProdSKUCreation.TabIndex = 2
        '
        'cmbx_PartCreateJigType
        '
        Me.cmbx_PartCreateJigType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_PartCreateJigType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_PartCreateJigType.FormattingEnabled = True
        Me.cmbx_PartCreateJigType.Location = New System.Drawing.Point(152, 113)
        Me.cmbx_PartCreateJigType.Name = "cmbx_PartCreateJigType"
        Me.cmbx_PartCreateJigType.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_PartCreateJigType.TabIndex = 105
        '
        'txtbx_PartCreatePartID
        '
        Me.txtbx_PartCreatePartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbx_PartCreatePartID.Location = New System.Drawing.Point(152, 158)
        Me.txtbx_PartCreatePartID.MaxLength = 20
        Me.txtbx_PartCreatePartID.Name = "txtbx_PartCreatePartID"
        Me.txtbx_PartCreatePartID.Size = New System.Drawing.Size(250, 29)
        Me.txtbx_PartCreatePartID.TabIndex = 15
        '
        'btnPartIDCreate
        '
        Me.btnPartIDCreate.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btnPartIDCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPartIDCreate.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPartIDCreate.ForeColor = System.Drawing.SystemColors.Window
        Me.btnPartIDCreate.Location = New System.Drawing.Point(420, 106)
        Me.btnPartIDCreate.Name = "btnPartIDCreate"
        Me.btnPartIDCreate.Size = New System.Drawing.Size(110, 60)
        Me.btnPartIDCreate.TabIndex = 16
        Me.btnPartIDCreate.Text = "Create"
        Me.btnPartIDCreate.UseVisualStyleBackColor = False
        '
        'dsp_PartIDCreation
        '
        Me.dsp_PartIDCreation.Dock = System.Windows.Forms.DockStyle.Top
        Me.dsp_PartIDCreation.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_PartIDCreation.Location = New System.Drawing.Point(0, 0)
        Me.dsp_PartIDCreation.Name = "dsp_PartIDCreation"
        Me.dsp_PartIDCreation.Size = New System.Drawing.Size(554, 50)
        Me.dsp_PartIDCreation.TabIndex = 103
        Me.dsp_PartIDCreation.Text = "Part ID Creation"
        Me.dsp_PartIDCreation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbx_PartCreateFilterType
        '
        Me.cmbx_PartCreateFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbx_PartCreateFilterType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbx_PartCreateFilterType.FormattingEnabled = True
        Me.cmbx_PartCreateFilterType.Location = New System.Drawing.Point(152, 68)
        Me.cmbx_PartCreateFilterType.Name = "cmbx_PartCreateFilterType"
        Me.cmbx_PartCreateFilterType.Size = New System.Drawing.Size(250, 29)
        Me.cmbx_PartCreateFilterType.TabIndex = 13
        '
        'dsp_PartCreatePartID
        '
        Me.dsp_PartCreatePartID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_PartCreatePartID.Location = New System.Drawing.Point(21, 159)
        Me.dsp_PartCreatePartID.Name = "dsp_PartCreatePartID"
        Me.dsp_PartCreatePartID.Size = New System.Drawing.Size(125, 25)
        Me.dsp_PartCreatePartID.TabIndex = 104
        Me.dsp_PartCreatePartID.Text = "Part ID :"
        Me.dsp_PartCreatePartID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_PartCreateFiltertype
        '
        Me.dsp_PartCreateFiltertype.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_PartCreateFiltertype.Location = New System.Drawing.Point(21, 69)
        Me.dsp_PartCreateFiltertype.Name = "dsp_PartCreateFiltertype"
        Me.dsp_PartCreateFiltertype.Size = New System.Drawing.Size(125, 25)
        Me.dsp_PartCreateFiltertype.TabIndex = 104
        Me.dsp_PartCreateFiltertype.Text = "Filter Type :"
        Me.dsp_PartCreateFiltertype.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dsp_PartCreateJigType
        '
        Me.dsp_PartCreateJigType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_PartCreateJigType.Location = New System.Drawing.Point(21, 114)
        Me.dsp_PartCreateJigType.Name = "dsp_PartCreateJigType"
        Me.dsp_PartCreateJigType.Size = New System.Drawing.Size(125, 25)
        Me.dsp_PartCreateJigType.TabIndex = 104
        Me.dsp_PartCreateJigType.Text = "Jig Type :"
        Me.dsp_PartCreateJigType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panel_FormControl
        '
        Me.panel_FormControl.Controls.Add(Me.PictureBox1)
        Me.panel_FormControl.Controls.Add(Me.dsp_Home)
        Me.panel_FormControl.Controls.Add(Me.btn_Home)
        Me.panel_FormControl.Controls.Add(Me.picbx_Icon)
        Me.panel_FormControl.Controls.Add(Me.panel_UserCategory)
        Me.panel_FormControl.Controls.Add(Me.Label1)
        Me.panel_FormControl.Controls.Add(Me.tabctrl_RecipeCtrl)
        Me.panel_FormControl.Controls.Add(Me.lbl_Version)
        Me.panel_FormControl.Controls.Add(Me.lbl_DateTimeClock)
        Me.panel_FormControl.Controls.Add(Me.lbl_Title)
        Me.panel_FormControl.Controls.Add(Me.lbl_OperationMode)
        Me.panel_FormControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_FormControl.Location = New System.Drawing.Point(0, 0)
        Me.panel_FormControl.Name = "panel_FormControl"
        Me.panel_FormControl.Size = New System.Drawing.Size(1904, 1001)
        Me.panel_FormControl.TabIndex = 0
        Me.panel_FormControl.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1631, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 106
        Me.PictureBox1.TabStop = False
        '
        'dsp_Home
        '
        Me.dsp_Home.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dsp_Home.Location = New System.Drawing.Point(1532, 49)
        Me.dsp_Home.Name = "dsp_Home"
        Me.dsp_Home.Size = New System.Drawing.Size(80, 25)
        Me.dsp_Home.TabIndex = 103
        Me.dsp_Home.Text = "Home"
        Me.dsp_Home.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Home
        '
        Me.btn_Home.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.btn_Home.BackgroundImage = CType(resources.GetObject("btn_Home.BackgroundImage"), System.Drawing.Image)
        Me.btn_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Home.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Home.Location = New System.Drawing.Point(1534, 77)
        Me.btn_Home.Name = "btn_Home"
        Me.btn_Home.Size = New System.Drawing.Size(80, 80)
        Me.btn_Home.TabIndex = 0
        Me.btn_Home.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1904, 46)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Recipe Management"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormRecipeManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1001)
        Me.Controls.Add(Me.panel_FormControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1920, 1040)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1918, 1030)
        Me.Name = "FormRecipeManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recipe Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picbx_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_UserCategory.ResumeLayout(False)
        Me.panel_UserCategory.PerformLayout()
        Me.tabpg_Delete.ResumeLayout(False)
        Me.panel_Delete.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.panel_RecipeDeletion.ResumeLayout(False)
        Me.panel_ProdSKUDeletion.ResumeLayout(False)
        Me.tabctrl_RecipeCtrl.ResumeLayout(False)
        Me.tabpg_RecipeDetails.ResumeLayout(False)
        Me.grpbx_Filter.ResumeLayout(False)
        Me.grpbx_Filter.PerformLayout()
        Me.grpbx_Search.ResumeLayout(False)
        Me.grpbx_Search.PerformLayout()
        CType(Me.dgv_RecipeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpg_Edit.ResumeLayout(False)
        Me.tabpg_Edit.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panel_RcpEditDrain3.ResumeLayout(False)
        Me.panel_RcpEditDrain3.PerformLayout()
        Me.panel_RcpEditDrain2.ResumeLayout(False)
        Me.panel_RcpEditDrain2.PerformLayout()
        Me.panel_RcpEditFlush2.ResumeLayout(False)
        Me.panel_RcpEditFlush2.PerformLayout()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.panel_RcpEditDrain1.ResumeLayout(False)
        Me.panel_RcpEditDrain1.PerformLayout()
        Me.panel_RcpEditDPTest1.ResumeLayout(False)
        Me.panel_RcpEditDPTest1.PerformLayout()
        Me.panel_RcpEditFlush1.ResumeLayout(False)
        Me.panel_RcpEditFlush1.PerformLayout()
        Me.panel_Edit.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panel_RecipeManagement.ResumeLayout(False)
        Me.tabpg_Create.ResumeLayout(False)
        Me.tabpg_Create.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.panel_RcpCreateDrain3.ResumeLayout(False)
        Me.panel_RcpCreateDrain3.PerformLayout()
        Me.panel_RcpCreateDrain2.ResumeLayout(False)
        Me.panel_RcpCreateDrain2.PerformLayout()
        Me.panel_RcpCreateFlush2.ResumeLayout(False)
        Me.panel_RcpCreateFlush2.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.panel_RcpCreateDrain1.ResumeLayout(False)
        Me.panel_RcpCreateDrain1.PerformLayout()
        Me.panel_RcpCreateDPTest1.ResumeLayout(False)
        Me.panel_RcpCreateDPTest1.PerformLayout()
        Me.panel_RcpCreateFlush1.ResumeLayout(False)
        Me.panel_RcpCreateFlush1.PerformLayout()
        Me.panel_Create.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.panel_RecipeGeneration.ResumeLayout(False)
        Me.panel_RecipeGeneration.PerformLayout()
        Me.panel_ProdSKUCreation.ResumeLayout(False)
        Me.panel_ProdSKUCreation.PerformLayout()
        Me.panel_FormControl.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Version As Label
    Friend WithEvents picbx_Icon As PictureBox
    Friend WithEvents lbl_DateTimeClock As Label
    Friend WithEvents lbl_Title As Label
    Friend WithEvents dsp_Category As Label
    Friend WithEvents lbl_Category As Label
    Friend WithEvents lbl_Username As Label
    Friend WithEvents dsp_Username As Label
    Friend WithEvents panel_UserCategory As Panel
    Friend WithEvents lbl_OperationMode As Label
    Friend WithEvents tabpg_Delete As TabPage
    Friend WithEvents tabctrl_RecipeCtrl As TabControl
    Friend WithEvents panel_FormControl As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Home As Button
    Friend WithEvents dsp_Home As Label
    Friend WithEvents tabpg_RecipeDetails As TabPage
    Friend WithEvents btn_RcpDetailExport As Button
    Friend WithEvents btn_RcpDetailImport As Button
    Friend WithEvents btn_RcpDetailEdit As Button
    Friend WithEvents btn_Search As Button
    Friend WithEvents btn_Reset As Button
    Friend WithEvents grpbx_Filter As GroupBox
    Friend WithEvents cmbx_RcpDetailType As ComboBox
    Friend WithEvents cmbx_RcpDetailPart As ComboBox
    Friend WithEvents cmbx_RcpDetailFilter As ComboBox
    Friend WithEvents dsp_FilterProdFamily As Label
    Friend WithEvents dsp_FilterProdSKU As Label
    Friend WithEvents dsp_FilterCategory As Label
    Friend WithEvents grpbx_Search As GroupBox
    Friend WithEvents dsp_SearchRecipeID As Label
    Friend WithEvents dgv_RecipeDetails As DataGridView
    Friend WithEvents panel_Delete As Panel
    Friend WithEvents tabpg_Edit As TabPage
    Friend WithEvents panel_Edit As Panel
    Friend WithEvents tabpg_Create As TabPage
    Friend WithEvents panel_Create As Panel
    Friend WithEvents panel_RecipeManagement As Panel
    Friend WithEvents panel_RecipeGeneration As Panel
    Friend WithEvents panel_ProdSKUCreation As Panel
    Friend WithEvents dsp_RcpEditRcpSelection As Label
    Friend WithEvents dsp_PartIDCreation As Label
    Friend WithEvents dsp_RcpEditRecipeID As Label
    Friend WithEvents dsp_RcpEditPartID As Label
    Friend WithEvents dsp_RcpEditFilterType As Label
    Friend WithEvents cmbx_RcpEditRecipeID As ComboBox
    Friend WithEvents cmbx_RcpEditPartID As ComboBox
    Friend WithEvents cmbx_RcpEditFilterType As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btn_RcpEdit As Button
    Friend WithEvents btn_EditDiscard As Button
    Friend WithEvents btn_RcpEditSave As Button
    Friend WithEvents cmbx_RcpCreateType As ComboBox
    Friend WithEvents cmbx_RcpCreateFilterType As ComboBox
    Friend WithEvents dsp_RcpCreateType As Label
    Friend WithEvents cmbx_RcpCreatePartID As ComboBox
    Friend WithEvents dsp_RcpCreatePart As Label
    Friend WithEvents dsp_RcpCreateRecipeID As Label
    Friend WithEvents dsp_RcpCreateFilter As Label
    Friend WithEvents txtbx_PartCreatePartID As TextBox
    Friend WithEvents btnPartIDCreate As Button
    Friend WithEvents cmbx_PartCreateFilterType As ComboBox
    Friend WithEvents dsp_PartCreatePartID As Label
    Friend WithEvents dsp_PartCreateFiltertype As Label
    Friend WithEvents dsp_PartCreateJigType As Label
    Friend WithEvents btn_RecipeIDCreate As Button
    Friend WithEvents txtbx_RcpCreateRecipeID As TextBox
    Friend WithEvents panel_RecipeDeletion As Panel
    Friend WithEvents dsp_RecipeDeletion As Label
    Friend WithEvents cmbx_RcpDeleteRecipeID As ComboBox
    Friend WithEvents btn_RecipeDelete As Button
    Friend WithEvents cmbx_RcpDeleteFilterType As ComboBox
    Friend WithEvents cmbx_RcpDeletePartID As ComboBox
    Friend WithEvents dsp_RcpDeletePartID As Label
    Friend WithEvents dsp_RcpDeleteRecipeID As Label
    Friend WithEvents dsp_RcpDeleteFilterType As Label
    Friend WithEvents panel_ProdSKUDeletion As Panel
    Friend WithEvents btn_PartDelete As Button
    Friend WithEvents dsp_ProdSKUDeletion As Label
    Friend WithEvents cmbx_PartDeleteFilterType As ComboBox
    Friend WithEvents dsp_ProdSKUDeletionSKU As Label
    Friend WithEvents dsp_ProdSKUDeletionPF As Label
    Friend WithEvents cmbx_PartDeletePartID As ComboBox
    Friend WithEvents cmbx_PartCreateJigType As ComboBox
    Friend WithEvents dsp_RcpCreateRcpParameters As Label
    Friend WithEvents panel_RcpCreateFlush1 As Panel
    Friend WithEvents txtbx_RcpCreateFlush1Time As TextBox
    Friend WithEvents dsp_RcpCreateFlush1Time As Label
    Friend WithEvents txtbx_RcpCreateFlush1Stabilize As TextBox
    Friend WithEvents dsp_RcpCreateFlush1Stabilize As Label
    Friend WithEvents txtbx_RcpCreateFlush1Pressure As TextBox
    Friend WithEvents dsp_RcpCreateFlush1Pressure As Label
    Friend WithEvents txtbx_RcpCreateFlush1FlowTol As TextBox
    Friend WithEvents dsp_RcpCreateFlush1FlowTol As Label
    Friend WithEvents txtbx_RcpCreateFlush1Flow As TextBox
    Friend WithEvents checkbx_CreateFlush1 As CheckBox
    Friend WithEvents dsp_RcpCreateFlush1Flow As Label
    Friend WithEvents panel_RcpCreateDPTest1 As Panel
    Friend WithEvents txtbx_RcpCreateDPTime As TextBox
    Friend WithEvents dsp_RcpCreateDPTime As Label
    Friend WithEvents txtbx_RcpCreateDPStabilize As TextBox
    Friend WithEvents dsp_RcpCreateDPStabilize As Label
    Friend WithEvents txtbx_RcpCreateDPPressure As TextBox
    Friend WithEvents dsp_RcpCreateDPPressure As Label
    Friend WithEvents txtbx_RcpCreateDPFlowTol As TextBox
    Friend WithEvents dsp_RcpCreateDPFlowTol As Label
    Friend WithEvents txtbx_RcpCreateDPFlow As TextBox
    Friend WithEvents checkbx_CreateDPTest1 As CheckBox
    Friend WithEvents dsp_RcpCreateDPFlow As Label
    Friend WithEvents panel_RcpCreateDrain1 As Panel
    Friend WithEvents txtbx_RcpCreateDrain1Time As TextBox
    Friend WithEvents dsp_RcpCreateDrain1Time As Label
    Friend WithEvents txtbx_RcpCreateDrain1Pressure As TextBox
    Friend WithEvents dsp_RcpCreateDrain1Pressure As Label
    Friend WithEvents checkbx_CreateDrain1 As CheckBox
    Friend WithEvents txtbx_RcpCreateDPPoints As TextBox
    Friend WithEvents dsp_RcpCreateDPPoints As Label
    Friend WithEvents txtbx_RcpCreateDPUpLimit As TextBox
    Friend WithEvents dsp_RcpCreateDPUpLimit As Label
    Friend WithEvents txtbx_RcpCreateDPLowLimit As TextBox
    Friend WithEvents dsp_RcpCreateDPLowLimit As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtbx_RcpCreateVerTol As TextBox
    Friend WithEvents dsp_RcpCreateVerTol As Label
    Friend WithEvents panel_RcpCreateFlush2 As Panel
    Friend WithEvents txtbx_RcpCreateFlush2Time As TextBox
    Friend WithEvents dsp_RcpCreateFlush2Time As Label
    Friend WithEvents txtbx_RcpCreateFlush2Stabilize As TextBox
    Friend WithEvents dsp_RcpCreateFlush2Stabilize As Label
    Friend WithEvents txtbx_RcpCreateFlush2Pressure As TextBox
    Friend WithEvents dsp_RcpCreateFlush2Pressure As Label
    Friend WithEvents txtbx_RcpCreateFlush2FlowTol As TextBox
    Friend WithEvents dsp_RcpCreateFlush2FlowTol As Label
    Friend WithEvents txtbx_RcpCreateFlush2Flow As TextBox
    Friend WithEvents checkbx_CreateFlush2 As CheckBox
    Friend WithEvents dsp_RcpCreateFlush2Flow As Label
    Friend WithEvents panel_RcpCreateDrain3 As Panel
    Friend WithEvents txtbx_RcpCreateDrain3Time As TextBox
    Friend WithEvents dsp_RcpCreateDrain3Time As Label
    Friend WithEvents txtbx_RcpCreateDrain3Pressure As TextBox
    Friend WithEvents dsp_RcpCreateDrain3Pressure As Label
    Friend WithEvents checkbx_CreateDrain3 As CheckBox
    Friend WithEvents panel_RcpCreateDrain2 As Panel
    Friend WithEvents txtbx_RcpCreateDrain2Time As TextBox
    Friend WithEvents dsp_RcpCreateDrain2Time As Label
    Friend WithEvents txtbx_RcpCreateDrain2Pressure As TextBox
    Friend WithEvents dsp_RcpCreateDrain2Pressure As Label
    Friend WithEvents checkbx_CreateDrain2 As CheckBox
    Friend WithEvents checkbx_CreateDPTest2 As CheckBox
    Friend WithEvents panel_RcpEditDrain3 As Panel
    Friend WithEvents txtbx_RcpEditDrain3Time As TextBox
    Friend WithEvents dsp_RcpEditDrain3Time As Label
    Friend WithEvents txtbx_RcpEditDrain3Pressure As TextBox
    Friend WithEvents dsp_RcpEditDrain3Pressure As Label
    Friend WithEvents checkbx_EditDrain3 As CheckBox
    Friend WithEvents panel_RcpEditDrain2 As Panel
    Friend WithEvents txtbx_RcpEditDrain2Time As TextBox
    Friend WithEvents dsp_RcpEditDrain2Time As Label
    Friend WithEvents txtbx_RcpEditDrain2Pressure As TextBox
    Friend WithEvents dsp_RcpEditDrain2Pressure As Label
    Friend WithEvents checkbx_EditDrain2 As CheckBox
    Friend WithEvents checkbx_EditDPTest2 As CheckBox
    Friend WithEvents panel_RcpEditFlush2 As Panel
    Friend WithEvents txtbx_RcpEditFlush2Time As TextBox
    Friend WithEvents dsp_RcpEditFlush2Time As Label
    Friend WithEvents txtbx_RcpEditFlush2Stabilize As TextBox
    Friend WithEvents dsp_RcpEditFlush2Stabilize As Label
    Friend WithEvents txtbx_RcpEditFlush2Pressure As TextBox
    Friend WithEvents dsp_RcpEditFlush2Pressure As Label
    Friend WithEvents txtbx_RcpEditFlush2FlowTol As TextBox
    Friend WithEvents dsp_RcpEditFlush2FlowTol As Label
    Friend WithEvents txtbx_RcpEditFlush2Flow As TextBox
    Friend WithEvents checkbx_EditFlush2 As CheckBox
    Friend WithEvents dsp_RcpEditFlush2Flow As Label
    Friend WithEvents Panel18 As Panel
    Friend WithEvents txtbx_RcpEditVerTol As TextBox
    Friend WithEvents dsp_RcpEditVerTol As Label
    Friend WithEvents panel_RcpEditDrain1 As Panel
    Friend WithEvents txtbx_RcpEditDrain1Time As TextBox
    Friend WithEvents dsp_RcpEditDrain1Time As Label
    Friend WithEvents txtbx_RcpEditDrain1Pressure As TextBox
    Friend WithEvents dsp_RcpEditDrain1Pressure As Label
    Friend WithEvents checkbx_EditDrain1 As CheckBox
    Friend WithEvents panel_RcpEditDPTest1 As Panel
    Friend WithEvents txtbx_RcpEditDPPoints As TextBox
    Friend WithEvents dsp_RcpEditDPPoints As Label
    Friend WithEvents txtbx_RcpEditDPUpLimit As TextBox
    Friend WithEvents dsp_RcpEditDPUpLimit As Label
    Friend WithEvents txtbx_RcpEditDPLowLimit As TextBox
    Friend WithEvents dsp_RcpEditDPLowLimit As Label
    Friend WithEvents txtbx_RcpEditDPTime As TextBox
    Friend WithEvents dsp_RcpEditDPTime As Label
    Friend WithEvents txtbx_RcpEditDPStabilize As TextBox
    Friend WithEvents dsp_RcpEditDPStabilize As Label
    Friend WithEvents txtbx_RcpEditDPPressure As TextBox
    Friend WithEvents dsp_RcpEditDPPressure As Label
    Friend WithEvents txtbx_RcpEditDPFlowTol As TextBox
    Friend WithEvents dsp_RcpEditDPFlowTol As Label
    Friend WithEvents txtbx_RcpEditDPFlow As TextBox
    Friend WithEvents checkbx_EditDPTest1 As CheckBox
    Friend WithEvents dsp_RcpEditDPFlow As Label
    Friend WithEvents panel_RcpEditFlush1 As Panel
    Friend WithEvents txtbx_RcpEditFlush1Time As TextBox
    Friend WithEvents dsp_RcpEditFlush1Time As Label
    Friend WithEvents txtbx_RcpEditFlush1Stabilize As TextBox
    Friend WithEvents dsp_RcpEditFlush1Stabilize As Label
    Friend WithEvents txtbx_RcpEditFlush1Pressure As TextBox
    Friend WithEvents dsp_RcpEditFlush1Pressure As Label
    Friend WithEvents txtbx_RcpEditFlush1FlowTol As TextBox
    Friend WithEvents dsp_RcpEditFlush1FlowTol As Label
    Friend WithEvents txtbx_RcpEditFlush1Flow As TextBox
    Friend WithEvents checkbx_EditFlush1 As CheckBox
    Friend WithEvents dsp_RcpEditFlush1Flow As Label
    Friend WithEvents dsp_RcpEditRcpParameters As Label
    Friend WithEvents cmbx_RcpDetailRecipeID As ComboBox
    Friend WithEvents btn_RcpDetailLoad As Button
    Friend WithEvents dsp_RcpCreation As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dsp_RcpDuplication As Label
    Friend WithEvents btn_RcpDuplicate As Button
    Friend WithEvents txtbx_RcpDupNewRecipeID As TextBox
    Friend WithEvents dsp_RcpDupNewRecipeID As Label
    Friend WithEvents dsp_RcpDupNewType As Label
    Friend WithEvents dsp_RcpDupSelRecipe As Label
    Friend WithEvents Cmbx_RcpDupNewType As ComboBox
    Friend WithEvents cmbx_RcpDupSelRecipe As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dsp_EditPreparation As Label
    Friend WithEvents dsp_RcpEditPrepBleed As Label
    Friend WithEvents dsp_RcpEditPrepFill As Label
    Friend WithEvents txtbx_RcpEditPrepBleed As TextBox
    Friend WithEvents txtbx_RcpEditPrepFill As TextBox
    Friend WithEvents dsp_RcpEditPressureDropTime As Label
    Friend WithEvents dsp_RcpEditPressureDrop As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dsp_RcpEditPrepPressure As Label
    Friend WithEvents dsp_RcpEditPrepFlow As Label
    Friend WithEvents txtbx_RcpEditPrepPressureDropTime As TextBox
    Friend WithEvents txtbx_RcpEditPrepPressureDrop As TextBox
    Friend WithEvents txtbx_RcpEditPrepPressure As TextBox
    Friend WithEvents txtbx_RcpEditPrepFlow As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dsp_CreatePreparation As Label
    Friend WithEvents dsp_RcpCreatePrepPressureDropTime As Label
    Friend WithEvents dsp_RcpCreatePrepPressureDrop As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dsp_RcpCreatePrepPressure As Label
    Friend WithEvents dsp_RcpCreatePrepFlow As Label
    Friend WithEvents dsp_RcpCreatePrepBleed As Label
    Friend WithEvents dsp_RcpCreatePrepFill As Label
    Friend WithEvents txtbx_RcpCreatePrepPressureDropTime As TextBox
    Friend WithEvents txtbx_RcpCreatePrepPressureDrop As TextBox
    Friend WithEvents txtbx_RcpCreatePrepPressure As TextBox
    Friend WithEvents txtbx_RcpCreatePrepFlow As TextBox
    Friend WithEvents txtbx_RcpCreatePrepBleed As TextBox
    Friend WithEvents txtbx_RcpCreatePrepFill As TextBox
    Friend WithEvents cmbx_RcpDetailRecipeIDRev As ComboBox
    Friend WithEvents dsp_RcpEditPrepPrefillTime As Label
    Friend WithEvents dsp_RcpEditPrepPrefillStartTime As Label
    Friend WithEvents txtbx_RcpEditPrepPrefillTime As TextBox
    Friend WithEvents txtbx_RcpEditPrepPrefillStartTime As TextBox
    Friend WithEvents dsp_RcpCreatePrepPrefillTime As Label
    Friend WithEvents dsp_RcpCreatePrepPrefillStartTime As Label
    Friend WithEvents txtbx_RcpCreatePrepPrefillTime As TextBox
    Friend WithEvents txtbx_RcpCreatePrepPrefillStartTime As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ComboBox7 As ComboBox
    Friend WithEvents ComboBox8 As ComboBox
    Friend WithEvents ComboBox9 As ComboBox
End Class
