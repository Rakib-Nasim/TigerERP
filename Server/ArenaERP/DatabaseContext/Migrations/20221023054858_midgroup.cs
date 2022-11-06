using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseContext.Migrations
{
    public partial class midgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Colors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountGroupLower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowerGroupId = table.Column<int>(type: "int", nullable: false),
                    MidGroupId = table.Column<int>(type: "int", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompId = table.Column<int>(type: "int", nullable: false),
                    GroupNameAlias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupNameAliasSaikat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AccType = table.Column<int>(type: "int", nullable: true),
                    BalancesheetCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfitLossCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundFlowCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: true),
                    BalanceType = table.Column<int>(type: "int", nullable: true),
                    BalancesheetPrintOrder = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true),
                    isBank = table.Column<int>(type: "int", nullable: true),
                    iSBankCash = table.Column<int>(type: "int", nullable: true),
                    PrintorderGroup = table.Column<int>(type: "int", nullable: true),
                    CashFlowId = table.Column<int>(type: "int", nullable: true),
                    CashFlowPO = table.Column<int>(type: "int", nullable: true),
                    TrailBalancePrintOrder = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsParent = table.Column<int>(type: "int", nullable: true),
                    BalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesAccounts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesCaption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroupLower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountGroupMid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MidGroupId = table.Column<int>(type: "int", nullable: true),
                    TopGroupId = table.Column<int>(type: "int", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: true),
                    BalanceType = table.Column<int>(type: "int", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountTypeID = table.Column<int>(type: "int", nullable: true),
                    IsAssets = table.Column<int>(type: "int", nullable: true),
                    AccType = table.Column<int>(type: "int", nullable: true),
                    AccountFlowType = table.Column<int>(type: "int", nullable: true),
                    Effect = table.Column<int>(type: "int", nullable: true),
                    IsBlank = table.Column<int>(type: "int", nullable: true),
                    isTrialBal1 = table.Column<int>(type: "int", nullable: true),
                    TrialBalaAfect = table.Column<int>(type: "int", nullable: true),
                    BalanceShetGrp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SdateBalancAffect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceSheetCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceSheetGroupCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintOrderTrialBalance = table.Column<int>(type: "int", nullable: true),
                    PrintOrderBalanceSheet = table.Column<int>(type: "int", nullable: true),
                    PrintOrderCashFlow = table.Column<int>(type: "int", nullable: true),
                    FundFlowCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundFlowGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintOrderFundFlow = table.Column<int>(type: "int", nullable: true),
                    PrintOrderIncomeStatement = table.Column<int>(type: "int", nullable: true),
                    PrintOrderProfitLoss = table.Column<int>(type: "int", nullable: true),
                    PrintOrderTrading = table.Column<int>(type: "int", nullable: true),
                    IncomeStateCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeStateCaption2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeStateCaption3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceForAppropriation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppropriationPrintOrder = table.Column<int>(type: "int", nullable: true),
                    IncomeStateCaption4 = table.Column<int>(type: "int", nullable: true),
                    IncomeStateCaption5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroupMid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountGroupTop",
                columns: table => new
                {
                    TopGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: true),
                    BalanceType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroupTop", x => x.TopGroupId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountGroupLower");

            migrationBuilder.DropTable(
                name: "AccountGroupMid");

            migrationBuilder.DropTable(
                name: "AccountGroupTop");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Colors");
        }
    }
}
