// File: MyPlugin.jslib

mergeInto(LibraryManager.library, {
  Send: function (csv) {
    window.dispatchReactUnityEvent(
      "Send",
	  Pointer_stringify(csv)
    );
  },
});
