module Program

open Suave
open System.Collections.Generic

let memos = new List<Entity.Memo>()

let app =
    choose [ MemoApi.createMemo memos; MemoApi.getMemo memos; MemoApi.getAllMemo memos ]

startWebServer defaultConfig app
