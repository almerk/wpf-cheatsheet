# Calendario entities for data transfer level between applications, with json serialization mechanisms

*Do not use in real projects with good architecture!*

The key feature is that dependent entities store references to different options for implementing their own properties and dimensions. 

When serializing these properties, only those characteristics are involved that will unambiguously determine the type of entity and its unique identifier (Nested entities flatten). 

Built-in deserialization mechanisms allow you to restore non-serialized properties of implementations, provided they have been obtained first.
