## 影片

### 1. 關鍵字搜尋

- **Filter**: 影片 / 頻道 / 撥放清單
- **Conditions**: type / duration / update
- **API**: `GET` `[https://www.googleapis.com/youtube/v3/search](https://www.googleapis.com/youtube/v3/search)`
- **Docs**: [Search: list](https://developers.google.com/youtube/v3/docs/search/list)

### 2. 取得影片資訊

- **API**: `GET` `https://www.googleapis.com/youtube/v3/videos`
- **Docs**: [Videos: list](https://developers.google.com/youtube/v3/docs/videos/list)

### 3. 對影片按讚倒讚

- **API**: `POST` `https://www.googleapis.com/youtube/v3/videos/rate`
- **Docs**: [Videos: rate](https://developers.google.com/youtube/v3/docs/videos/rate)

### 4. 將影片加入指定撥放清單

- **API**: `POST` `https://www.googleapis.com/youtube/v3/playlistItems`
- **Docs**: [PlaylistItems: Insert](https://developers.google.com/youtube/v3/docs/playlistItems/insert)

### 5.1 上傳影片 斷點續傳

- **API**: `POST` `https://www.googleapis.com/upload/youtube/v3/videos`
- **Docs**: [Videos Insert](https://developers.google.com/youtube/v3/docs/videos/insert)
- **Guide**: [Using Resumable Upload Protocol](https://developers.google.com/youtube/v3/guides/using_resumable_upload_protocol)

### 5.2 上傳影片 單次上傳

- **API**: `POST` `https://www.googleapis.com/upload/youtube/v3/videos`
- **Docs**: [Videos Insert](https://developers.google.com/youtube/v3/docs/videos/insert)
- **Guide**: [Manage Uploads](https://developers.google.com/workspace/drive/api/guides/manage-uploads#multipart)

### 6. 修改影片資訊

- **API**: `PUT` `https://www.googleapis.com/youtube/v3/videos`
- **Docs**: [Videos Update](https://developers.google.com/youtube/v3/docs/videos/update)

### 7. 刪除影片

- **API**: `DELETE` `https://www.googleapis.com/youtube/v3/videos`
- **Docs**: [Videos Delete](https://developers.google.com/youtube/v3/docs/videos/delete)

### 8. 查看自己喜歡的影片

- **API**: `GET` `https://www.googleapis.com/youtube/v3/videos`
  - **Parameter**: `myRating: like `
- **Docs**: [Videos List](https://developers.google.com/youtube/v3/docs/videos/list)

### 9. 查看自己不喜歡的影片

- **API**: `GET` `https://www.googleapis.com/youtube/v3/videos`
  - **Parameter**: `myRating: dislike `
- **Docs**: [Videos List](https://developers.google.com/youtube/v3/docs/videos/list)

### 10. 查看自己發布的影片

- **API**: `GET` `https://www.googleapis.com/youtube/v3/search`
  - **Parameter**: `forMine: true`, `type: video`
- **Docs**: [Search List](https://developers.google.com/youtube/v3/docs/search/list)

## 訂閱

### 11. 訂閱頻道

- **API**: `POST` `https://www.googleapis.com/youtube/v3/subscriptions`

- **Docs**: [Subscriptions Insert](https://developers.google.com/youtube/v3/docs/subscriptions/insert)

### 12. 取消訂閱頻道

- **API**: `DELETE ` `https://www.googleapis.com/youtube/v3/subscriptions`

- **Docs**: [Subscriptions Delete](https://developers.google.com/youtube/v3/docs/subscriptions/delete)

## 撥放清單

### 13. 建立撥放清單

- **API**: `POST` `https://www.googleapis.com/youtube/v3/playlists`

- **Docs**: [Playlists Insert](https://developers.google.com/youtube/v3/docs/playlists/insert)

### 14. 刪除撥放清單

- **API**: `DELETE` `https://www.googleapis.com/youtube/v3/playlists`
- **Docs**: [Playlists Delete](https://developers.google.com/youtube/v3/docs/playlists/delete)

### 15. 編輯撥放清單

- **API**: `PUT` `https://www.googleapis.com/youtube/v3/playlists`
- **Docs**: [Playlists Update](https://developers.google.com/youtube/v3/docs/playlists/update)

## 評論

### 16. 取得指定影片評論

- **API**: `GET` ` https://www.googleapis.com/youtube/v3/commentThreads`
- **Docs**: [CommentThreads List](https://developers.google.com/youtube/v3/docs/commentThreads/list)

### 17. 取得指定評論下的所有頻論

- **API**: `GET` `https://www.googleapis.com/youtube/v3/comments`
- **Docs**: [Comment List](https://developers.google.com/youtube/v3/docs/comments/list)

### 18. 發布頻論

- **API**: `POST` `https://www.googleapis.com/youtube/v3/commentThreads`
- **Docs**: [commentThreads Insert](https://developers.google.com/youtube/v3/docs/commentThreads/insert)

### 19. 刪除頻論

- **API**: `DELETE` `https://www.googleapis.com/youtube/v3/comments`
- **Docs**: [Comments Delete](https://developers.google.com/youtube/v3/docs/comments/delete)

### 20. 修改評論

- **API**: `PUT` `https://www.googleapis.com/youtube/v3/comments`
- **Docs**: [Comments Update](https://developers.google.com/youtube/v3/docs/comments/update)

## 頻道

### 21. 取得頻道資訊

- **API**: `GET` `https://www.googleapis.com/youtube/v3/channels`
- **Docs**: [Channels List](https://developers.google.com/youtube/v3/docs/channels/list)
