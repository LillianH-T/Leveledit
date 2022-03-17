
mergeInto(LibraryManager.library, {
  send: function(csv){
    window.dispatchReactUnityEvent(
      "send",
      Pointer_stringify(csv)
    );
  },
});
