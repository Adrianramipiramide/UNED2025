using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GestorCuentas.Services;

public class AdapterStorage(Task<IJSObjectReference> jsModule) {
	// private ValueTask<IJSObjectReference> jsModule = ;
	private IJSObjectReference? module;


	public async Task<T> GetValueAsync<T>(string key) {
		module ??= await jsModule;
		return await module.InvokeAsync<T>("get", key);
	}

	public async Task SetValueAsync<T>(string key, T value) {
		module ??= await jsModule;
		await module.InvokeVoidAsync("set", key, value);
	}

	public async Task Clear() {
		module ??= await jsModule;
		await module.InvokeVoidAsync("clear");
	}

	public async Task RemoveAsync(string key) {
		module ??= await jsModule;
		await module.InvokeVoidAsync("remove", key);
	}
}

public class BrowserPersistence {
	#region PRIVATE

	private IJSObjectReference? module;

	public BrowserPersistence(IJSRuntime jsRuntime, NavigationManager navManager) {
		var getSession = async () => {
			var mainModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", $"{navManager.BaseUri}js/BrowserPersistence.js");
			return await mainModule.InvokeAsync<IJSObjectReference>("getAdapter", "session");
		};

		var getLocal = async () => {
			var mainModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", $"{navManager.BaseUri}js/BrowserPersistence.js");
			return await mainModule.InvokeAsync<IJSObjectReference>("getAdapter", "local");
		};

		sessionStorage = new AdapterStorage(getSession());
		localStorage = new AdapterStorage(getLocal());
	}

	#endregion

	#region "PUBLIC"

	public AdapterStorage sessionStorage { get; private set; }
	public AdapterStorage localStorage { get; private set; }

	#endregion
}
