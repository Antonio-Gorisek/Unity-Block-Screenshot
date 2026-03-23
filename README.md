# Unity Secure Screen (Android)

This solution uses the Android system flag `FLAG_SECURE` to protect the content of the application from being recorded and displayed outside the application itself.

<img width="1600" height="900" alt="image" src="https://github.com/user-attachments/assets/150702de-9f35-4e4e-b348-353bf92f7d52" />

---

## How it works

Android has a built-in security mechanism at the application window level.
When `FLAG_SECURE` is turned on, the operating system automatically restricts access to the visual content of the application to other processes.
This means that Android treats the content of the application as "protected" and does not allow its copy or display outside the active window.

---

## What exactly does it do

When protection is on:

* blocks standard screenshot (keys or system API)
* blocks most screen recording tools (including built-in ones)
* removes content from the "recent apps" view (the thumbnail becomes black or empty)
* prevents other applications from reading the screen (eg screen capture API)

In other words: the content of your application remains visible only within the application itself.

---

## How it behaves in practice

* user tries to screenshot → gets a black image
* user records the screen → the video is black
* user opens the app switcher → does not see the content of your app
* when the app returns from the background → protection must still be kept active
