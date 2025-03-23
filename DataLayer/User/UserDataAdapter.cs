﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class UserDataAdapter : IDataAdaper
    {
        public string Table => "users";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (login, password, first_name, second_name, last_name, reg_type, is_reg) 
                                    values(
                                            @{nameof(User.Login)},@{nameof(User.Password)},@{nameof(User.FirstName)},
                                            @{nameof(User.SecondName)},@{nameof(User.LastName)},@{nameof(User.RegType)},@{nameof(User.IsReg)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set login = @{nameof(User.Login)},password  = @{nameof(User.Password)},
                                first_name = @{nameof(User.FirstName)}, second_name = @{nameof(User.SecondName)}, 
                                last_name = @{nameof(User.LastName)}, reg_type = @{nameof(User.RegType)}, is_reg = @{nameof(User.IsReg)}
                        where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    id as {nameof(User.Id)}, login as {nameof(User.Login)}, password as {nameof(User.Password)}, 
                        first_name as {nameof(User.FirstName)}, second_name as {nameof(User.SecondName)}, last_name as {nameof(User.LastName)}, 
                        reg_type as {nameof(User.RegType)}, is_reg as {nameof(User.IsReg)}
                    from 
	                    {Table}
                    ";
        }
    }
}
