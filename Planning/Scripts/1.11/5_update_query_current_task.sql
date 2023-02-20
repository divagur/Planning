update pl_query set qry_First =

 ' select q.*,cast(    (case          when s_in is not NULL then 0xFF000000 /*red*/     else 0xFF000000 /*black*/    end) as int) FontColor,  cast(      (       case            when getdate() > cast(convert(varchar,s_date,104) +'' ''+cast(slot_time as varchar) as datetime) then 0xFFFF0000        when s_in = 1 then 0xFFED7D31                 else 0XFF5B9BD5        end      ) as int   ) BackgroundColor              from (  '
 where qry_ID = 2