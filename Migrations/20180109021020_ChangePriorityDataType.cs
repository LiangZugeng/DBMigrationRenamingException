using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MigrationRenamingException.Migrations
{
    public partial class ChangePriorityDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ushort>(
                name: "PriorityNew",
                table: "Posts",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: 1
            );

            // copy the value from Priority to PriorityNew
            migrationBuilder.Sql("update Posts set PriorityNew = case when Priority = 'Normal' then 1 when Priority = 'Urgent' then 2 when Priority = 'Immediate' then 3 else 1 end", true);

            migrationBuilder.DropColumn("Priority", "Posts");

            migrationBuilder.RenameColumn("PriorityNew", "Posts", "Priority");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
