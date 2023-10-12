using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class LookupViewModels
    {
        public class JobStatusViewModel
        {
            public int JobStatusId { get; set; }
            public string JobStatusName { get; set;}
        }
        public class ColorViewModel
        {
            public int ColorId { get; set; }
            public string ColorName { get; set;}
        }
        public class RoleViewModel
        {
            public int RoleId { get; set;}
            public int WorkshopId { get; set; }
            public string RoleName { get; set;}
            public string RoleNameAr { get; set;}
            public string? WorkshopName { get; set;}
        }
        public class UpdateRoleViewModel
        {
            public int WorkshopId { get; set; }
            public string RoleName { get; set; }
            public string RoleNameAr { get; set; }
        }
        public class StageViewModel
        {
            public int StageId { get; set; }
            public int StageNo { get; set; }
            public int WorkshopId { get; set; }
            public string StageName { get; set;}
            public string StageNameAr { get; set;}
            public string? WorkshopName { get; set; }
        }
        public class Column
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public List<Task> TaskIds { get; set; }
           
        }
        public class TasksResponse
        {
            public List<ColOrder> ColumnOrder { get; set; }
            public Dictionary<string, ColumnData> Columns { get; set; }
        }
        public class ColOrder
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class ColumnData
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public List<string> TaskIds { get; set; }
        }
        public class Task
        {
            public int Id { get; set; }
            public string Content { get; set; }
            public int ColumnId { get; set; }
            public Column Column { get; set; }
        }
        public class KanbanStageViewModel
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public class VehicleMakeViewModel
        {
            public int VehicleMakeId { get; set; }
            public string VehicleMakeName { get; set; }
            public string VehicleMakeNameAr { get; set; }
        }
        public class VehicleModelViewModel
        {
            public int VehicleModelId { get; set; }
            public int VehicleMakeId { get; set; }
            public string? VehicleMakeName { get; set; }
            public string? VehicleMakeNameAr { get; set; }
            public string VehicleModelName { get; set; }
            public string VehicleModelNameAr { get; set; }
        }
        public class CustomerTypeViewModel
        {
            public int CustomerTypeId { get; set; }

            public string CustomerTypeName { get; set; }
            public string CustomerTypeNameAr { get; set; }
        }
    }
}
