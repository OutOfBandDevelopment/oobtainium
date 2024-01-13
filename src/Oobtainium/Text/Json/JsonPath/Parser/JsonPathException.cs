using System;

namespace OoBDev.Oobtainium.Text.Json.JsonPath.Parser;

public class JsonPathException(string message) : Exception(message)
{
}