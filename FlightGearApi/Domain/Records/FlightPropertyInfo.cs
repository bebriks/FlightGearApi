﻿namespace FlightGearApi.Domain.Records;

public record FlightPropertyInfo(string Path, string Name, Type Type, string TypeName, string FormatValue, double Multifier = 1);