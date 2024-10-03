# Server World Update On Thread

This is an project based on the Unity Asteroids sample show-casing a surprisingly functional example of running the Server World update on another thread which isn't the main thread. InitializationSystemGroup is still on main thread.

1. Open the Netcode samples [Netcode samples](./NetcodeSamples) project
2. Disable JobsDebugger
3. Open and run the Asteroids scene
4. The ServerWorld update is run on a non-main thread as can be seen in the profiler

![Screenshot 2024-10-03 232140](https://github.com/user-attachments/assets/159ebaf4-11ba-4564-9da1-d12cef78cf8c)

This is just a very quick and dirty implementation. Some obvious problems:
- JobsDebugger doesn't work.
- Might have some weird race condition with scheduling jobs on both main thread and server update thread.
- Allocator.Temp doesn't work on server update thread (changed a lot of these to TempJob).
- Didn't care about fixing leaks after Temp -> TempJob change so there is a lot of TempJob leaks.
