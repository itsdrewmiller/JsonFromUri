JsonFromUri
====

This is a simple attribute for deserializing JSON from URI parameters in Microsoft ASP.NET Web API.  It is available as a nuget package of the same name.  Here is an example usage:

    <[GET]("v4/somethings")>
    Public Function GetValues(<JsonFromUri(GetType(SomeFilterDTO))> filter As SomeFilterDTO) As IEnumerable(Of SomeDTO)

I suspect there is some way to identify the type of the parameter without directly passing it to the attribute - it should be straightforward to add an overloaded constructor with no parameters, if anyone knows how to find that type.  :-)

