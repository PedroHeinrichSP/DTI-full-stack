import axios from 'axios';

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
});

export const getLeads = async (status: "invited" | "accepted") => {
    const response = await api.get(`/leads?status=${status}`);
    return response.data;
};

export const acceptLead = async (id: number) => {
    const response = await api.post(`/leads/${id}/accept`);
    return response.data;
};

export const declineLead = async (id: number) => {
    const response = await api.post(`/leads/${id}/decline`);
    return response.data;
};

export default api;