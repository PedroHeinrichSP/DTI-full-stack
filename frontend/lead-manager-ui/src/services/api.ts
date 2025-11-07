import axios from 'axios';

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
});

export const getLeads = async (status: string) => {
    const response = await api.get(`/leads?status=${status}`);
    return response.data;
};

export const acceptLead = async (id: number, confirmedPrice?: number) => {
  try {
    const params = confirmedPrice ? { confirmedPrice } : undefined;
    const response = await api.post(`/leads/${id}/accept`, null, { params });
    return response.data;
  } catch (error: any) {
    if (error.response?.data?.requiresConfirmation) {
      return { requiresConfirmation: true, ...error.response.data };
    }
    throw error;
  }
};

export const declineLead = async (id: number) => {
    const response = await api.post(`/leads/${id}/decline`);
    return response.data;
};

export default api;