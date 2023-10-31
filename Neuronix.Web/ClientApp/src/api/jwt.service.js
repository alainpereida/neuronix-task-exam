import {
    SESSION_TOKEN_KEY
} from "../constants/constants";

export const getToken = () => {
    return window.localStorage.getItem(SESSION_TOKEN_KEY)
};

export const getSession = () => {
    return window.localStorage.getItem(SESSION_TOKEN_KEY);
};

export const saveToken = (token) => {
    window.localStorage.setItem(SESSION_TOKEN_KEY, token);
};

export const destroyToken = () => {
    window.localStorage.removeItem(SESSION_TOKEN_KEY);
};

export default {
    getToken,
    saveToken,
    destroyToken,
    getSession
};
