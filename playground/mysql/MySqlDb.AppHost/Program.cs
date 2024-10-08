// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

var builder = DistributedApplication.CreateBuilder(args);

var catalogDbName = "catalog"; // MySql database & table names are case-sensitive on non-Windows.
var catalogDb = builder.AddMySql("mysql")
    .WithEnvironment("MYSQL_DATABASE", catalogDbName)
    .WithBindMount("../MySql.ApiService/data", "/docker-entrypoint-initdb.d")
    .WithPhpMyAdmin()
    .AddDatabase(catalogDbName);

builder.AddProject<Projects.MySql_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WithReference(catalogDb).WaitFor(catalogDb);

builder.Build().Run();
