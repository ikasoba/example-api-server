module Entity

open System.Runtime.Serialization
open System

[<DataContract>]
type Memo =
    { [<field: DataMember(Name = "id")>]
      id: int

      [<field: DataMember(Name = "title")>]
      title: string

      [<field: DataMember(Name = "content")>]
      content: string

      [<field: DataMember(Name = "createdAt")>]
      createdAt: DateTime }
