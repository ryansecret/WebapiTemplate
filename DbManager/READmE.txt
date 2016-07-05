
Enable-Migrations

Add-Migration 名称 

Update-Database –Verbose

Update-Database -Script -SourceMigration: $InitialDatabase -TargetMigration: 名称  生成sql