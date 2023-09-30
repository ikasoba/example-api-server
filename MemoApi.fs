module MemoApi

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.Json
open System.Runtime.Serialization
open System
open System.Collections.Generic

[<DataContract>]
type CreateMemoRequest =
    { [<field: DataMember(Name = "title")>]
      title: string

      [<field: DataMember(Name = "content")>]
      content: string }

let createMemo (memos: Entity.Memo List) : WebPart =
    path "/memos/new"
    >=> mapJson (fun (req: CreateMemoRequest) ->
        let memo: Entity.Memo =
            { id = memos.Count
              title = req.title
              content = req.content
              createdAt = DateTime.Now }

        memos.Add(memo)
        memo)

let getMemo (memos: Entity.Memo List) : WebPart =
    pathScan "/memos/%d" (fun id -> mapJson (fun () -> memos[id]))

let getAllMemo (memos: Entity.Memo List) : WebPart =
    path "/memos/all" >=> (mapJson (fun () -> memos))
