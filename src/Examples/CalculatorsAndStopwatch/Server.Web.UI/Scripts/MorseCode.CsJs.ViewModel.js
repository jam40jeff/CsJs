(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.ApplicationViewModelBase
	var $MorseCode_CsJs_ViewModel_ApplicationViewModelBase = function() {
		this.currentViewModelInternal = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Object]))();
	};
	$MorseCode_CsJs_ViewModel_ApplicationViewModelBase.prototype = {
		get_currentViewModel: function() {
			return this.currentViewModelInternal;
		},
		get_defaultViewModel: null,
		onError: null,
		get_errorHandler: function() {
			return ss.mkdel(this, this.onError);
		},
		initialize: function() {
			this.currentViewModelInternal.set_value$2(this.get_defaultViewModel());
		}
	};
	ss.registerClass(global, 'MorseCode.CsJs.ViewModel.ApplicationViewModelBase', $MorseCode_CsJs_ViewModel_ApplicationViewModelBase);
})();
