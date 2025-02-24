

class SessionStorage {
    get(key) {
        return sessionStorage.getItem(key);
    }

    set(key, value) {
        sessionStorage.setItem(key, value);
    }

    clear() {
        sessionStorage.clear();
    }

    remove(key) {
        sessionStorage.removeItem(key);
    }
}

class LocalStorage {
    get(key) {
        return window.localStorage.getItem(key);
    }

    set(key, value) {
        window.localStorage.setItem(key, value);
    }

    clear() {
        window.localStorage.clear();
    }

    remove(key) {
        window.localStorage.removeItem(key);
    }
}

export function getAdapter(type) {
    if (type == "session") return new SessionStorage();
    else if (type == "local") return new LocalStorage();

    return new SessionStorage();
}