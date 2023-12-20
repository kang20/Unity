mergeInto(LibraryManager.library, {
	newplay: function(initstr) {
		var newstr = UTF8ToString(initstr);
		window.dispatchReactUnityEvent("newplay", newstr);
	},

	info: function(playerstr){
		var infostr = UTF8ToString(playerstr);
		window.dispatchReactUnityEvent("info", infostr);
	},
	BuildComplete: function(){},
});
