using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hospital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealingEventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealingEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalizationConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalizationConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalizationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalizationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCredentials_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMainInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PassportSeries = table.Column<long>(type: "bigint", nullable: false),
                    PassportNumber = table.Column<long>(type: "bigint", nullable: false),
                    GenderId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMainInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMainInfos_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMainInfos_UserCredentials_UserId",
                        column: x => x.UserId,
                        principalTable: "UserCredentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HospitalizationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserInfoId = table.Column<int>(type: "integer", nullable: false),
                    Diagnosis = table.Column<string>(type: "text", nullable: true),
                    Target = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    HospitalizationConditionId = table.Column<int>(type: "integer", nullable: false),
                    HospitalizationStatisId = table.Column<int>(type: "integer", nullable: false),
                    HospitalizationStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_Departaments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_HospitalizationConditions_HospitalizationC~",
                        column: x => x.HospitalizationConditionId,
                        principalTable: "HospitalizationConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_HospitalizationStatuses_HospitalizationSta~",
                        column: x => x.HospitalizationStatusId,
                        principalTable: "HospitalizationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_UserMainInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: true),
                    UserMainInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalCards_UserMainInfos_UserMainInfoId",
                        column: x => x.UserMainInfoId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VisitorId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestVisits_UserMainInfos_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestVisits_UserMainInfos_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdditionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    WorkPlace = table.Column<string>(type: "text", nullable: true),
                    InsurancePolicyNumber = table.Column<long>(type: "bigint", nullable: true),
                    InsurancePolicyDateEnf = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserMainInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdditionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdditionals_UserMainInfos_UserMainInfoId",
                        column: x => x.UserMainInfoId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealingEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    HealingEventTypeId = table.Column<int>(type: "integer", nullable: false),
                    Results = table.Column<string>(type: "text", nullable: true),
                    Recommendation = table.Column<string>(type: "text", nullable: true),
                    RequestVisitId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealingEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealingEvents_HealingEventTypes_HealingEventTypeId",
                        column: x => x.HealingEventTypeId,
                        principalTable: "HealingEventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealingEvents_RequestVisits_RequestVisitId",
                        column: x => x.RequestVisitId,
                        principalTable: "RequestVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealingEvents_UserMainInfos_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealingEvents_UserMainInfos_PatientId",
                        column: x => x.PatientId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalCardId = table.Column<int>(type: "integer", nullable: false),
                    Recommaendation = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    RequestVisitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_MedicalCards_MedicalCardId",
                        column: x => x.MedicalCardId,
                        principalTable: "MedicalCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_RequestVisits_RequestVisitId",
                        column: x => x.RequestVisitId,
                        principalTable: "RequestVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_UserMainInfos_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "UserMainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departaments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Онкологическое отделение" },
                    { 2, "Хирургическое отделение" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Man" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "HealingEventTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Лабораторное Исследование" },
                    { 2, "Инструментальная Диагностика" },
                    { 3, "Лекарственная Терапия" },
                    { 4, "Физиотерапия" },
                    { 5, "Хирургическое лечение" }
                });

            migrationBuilder.InsertData(
                table: "HospitalizationConditions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Платно" },
                    { 2, "Бюджет" }
                });

            migrationBuilder.InsertData(
                table: "HospitalizationStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Госпитализирован" },
                    { 2, "Отменено" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Doctor" },
                    { 3, "Receptionist" },
                    { 4, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealingEvents_DoctorId",
                table: "HealingEvents",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_HealingEvents_HealingEventTypeId",
                table: "HealingEvents",
                column: "HealingEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealingEvents_PatientId",
                table: "HealingEvents",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HealingEvents_RequestVisitId",
                table: "HealingEvents",
                column: "RequestVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_DepartmentId",
                table: "Hospitalizations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_HospitalizationConditionId",
                table: "Hospitalizations",
                column: "HospitalizationConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_HospitalizationStatusId",
                table: "Hospitalizations",
                column: "HospitalizationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_UserInfoId",
                table: "Hospitalizations",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCards_UserMainInfoId",
                table: "MedicalCards",
                column: "UserMainInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestVisits_DoctorId",
                table: "RequestVisits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestVisits_VisitorId",
                table: "RequestVisits",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdditionals_UserMainInfoId",
                table: "UserAdditionals",
                column: "UserMainInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_RoleId",
                table: "UserCredentials",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMainInfos_GenderId",
                table: "UserMainInfos",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMainInfos_UserId",
                table: "UserMainInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_MedicalCardId",
                table: "Visits",
                column: "MedicalCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_RequestVisitId",
                table: "Visits",
                column: "RequestVisitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealingEvents");

            migrationBuilder.DropTable(
                name: "Hospitalizations");

            migrationBuilder.DropTable(
                name: "UserAdditionals");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "HealingEventTypes");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.DropTable(
                name: "HospitalizationConditions");

            migrationBuilder.DropTable(
                name: "HospitalizationStatuses");

            migrationBuilder.DropTable(
                name: "MedicalCards");

            migrationBuilder.DropTable(
                name: "RequestVisits");

            migrationBuilder.DropTable(
                name: "UserMainInfos");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "UserCredentials");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
