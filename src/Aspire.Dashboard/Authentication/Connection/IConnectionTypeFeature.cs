// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Aspire.Dashboard.Authentication.Connection;

/// <summary>
/// This feature's presence on a connection indicates that the connection is for OTLP.
/// </summary>
internal interface IConnectionTypeFeature
{
    List<ConnectionType> ConnectionTypes { get; }
}
