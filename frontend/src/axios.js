import axios from "axios";
import store from "./store/store";

axios.defaults.baseURL="https://localhost:7224/"

axios.defaults.withCredentials = true;

axios.interceptors.request.use(function (config) {
    const token = store.state.user?.token; 
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
}, function (error) {
    return Promise.reject(error);
});

export default axios;