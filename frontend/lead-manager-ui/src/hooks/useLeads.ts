import { useState, useEffect } from "react";
import { getLeads, acceptLead, declineLead } from "../services/api";

export function useLeads(status: string) {
  const [leads, setLeads] = useState<any[]>([]);
  const [loading, setLoading] = useState(true);
  const [confirmModal, setConfirmModal] = useState<{
    id: number;
    suggestedPrice: number;
    message: string;
  } | null>(null);

  useEffect(() => {
    (async () => {
      const data = await getLeads(status);
      setLeads(data);
      setLoading(false);
    })();
  }, [status]);

  const handleAccept = async (id: number) => {
    const res = await acceptLead(id);
    if (res.requiresConfirmation) {
      setConfirmModal({
        id,
        suggestedPrice: res.suggestedPrice,
        message: res.message,
      });
    } else {
      setLeads((prev) => prev.filter((lead) => lead.id !== id));
    }
  };

  const handleConfirmAccept = async (id: number, confirmedPrice: number) => {
    await acceptLead(id, confirmedPrice);
    setLeads((prev) => prev.filter((lead) => lead.id !== id));
    setConfirmModal(null);
  };

  const handleDecline = async (id: number) => {
    await declineLead(id);
    setLeads((prev) => prev.filter((lead) => lead.id !== id));
  };

  return {
    leads,
    loading,
    handleAccept,
    handleDecline,
    confirmModal,
    handleConfirmAccept,
    setConfirmModal,
  };
}
