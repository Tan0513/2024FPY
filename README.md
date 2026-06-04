3D 射擊遊戲

專案定位

以 FPS 操作與戰鬥流程為核心的 3D 射擊遊戲，著重於即時操作體驗與敵人行為設計。

負責內容
* 建立 FPS 玩家控制系統
* 設計射擊與命中判定機制
* 建立敵人 AI 行為與追蹤邏輯
* 實作 UI 與血量系統
* 製作後處理效果與粒子系統
* 建立任務事件系統


系統設計重點
* 使用 Raycast 處理射擊判定，確保即時性與準確性
* 將玩家控制、射擊邏輯與 UI 系統分離，降低系統耦合
* 使用 NavMesh 建立敵人移動與追蹤行為，提升 AI 可調整性
* 導入 Object Pool 管理子彈與效果物件，降低效能開銷


使用技術
* Unity Character Controller
* Raycast 判定
* NavMesh AI
* Object Pool


游戲影片
https://youtu.be/DbjnCBdSlQY

----------------------------------------------------------------------------------------------------
角色用animator和input system來移動

![image](https://github.com/user-attachments/assets/62c5a4ce-cf4a-482a-bd64-5e2cd62f1687)

解決第一人稱視覺方法是手身分離，并且使用Virtual Camera

![image](https://github.com/user-attachments/assets/2e56e643-158a-4bff-9007-e0e8651e1eec)

脚步聲音用event校准

![image](https://github.com/user-attachments/assets/dd2c67b2-7913-4da3-b4bf-58ea59899ea4)

用collider觸發事件

![2024FTY4 5 - 防禦模式 - Windows, Mac, Linux - Unity 2022 3 12f1 _DX11_ 2025-07-01 22-18-45](https://github.com/user-attachments/assets/b530a5b2-d9f5-4356-b8ed-0a39a984178e)

有爆頭判定且有UI顯示，有噴血的粒子效果，渲染風格參考致命公司

![2024FTY4 5 - 防禦模式 - Windows, Mac, Linux - Unity 2022 3 12f1 _DX11_ 2025-07-01 22-18-45 (1)](https://github.com/user-attachments/assets/f7792cc9-c173-4950-b936-b87d8635a1de)

子彈采用物件池(Pool)來處理

![2024FTY4 5 - 防禦模式 - Windows, Mac, Linux - Unity 2022 3 12f1 _DX11_ 2025-07-02 06-48-58](https://github.com/user-attachments/assets/34e76633-f7ed-4926-adab-f522d74335a4)

程式控制敵人AI，並以Nav Mesh尋路

![image](https://github.com/user-attachments/assets/f704922e-b345-4b98-906c-19cd8f861b05)
