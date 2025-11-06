import type { LeadCardProps } from "../components/LeadCard";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { getLeads, acceptLead, declineLead } from "../services/api";
import { toast } from "sonner";

export function useLeads(status: "invited" | "accepted") {
    const queryClient = useQueryClient();

    const { data, isLoading, isError } = useQuery<LeadCardProps[]>({
        queryKey: ["leads", status],
        queryFn: () => getLeads(status),
    });

    const acceptMutation = useMutation({
        mutationFn: (id: number) => acceptLead(id),
        onSuccess: () => {
            toast.success("Lead accepted successfully");
            queryClient.invalidateQueries({ queryKey: ["leads", "invited"] });
            queryClient.invalidateQueries({ queryKey: ["leads", "accepted"] });
        },
        onError: () => {
            toast.error("Failed to accept lead");
        },
    });

    const declineMutation = useMutation({
        mutationFn: (id: number) => declineLead(id),
        onSuccess: () => {
            toast.success("Lead declined successfully");
            queryClient.invalidateQueries({ queryKey: ["leads", "invited"] });
            queryClient.invalidateQueries({ queryKey: ["leads", "accepted"] });
        },
        onError: () => {
            toast.error("Failed to decline lead");
        },
    });

    console.log("Leads recebidos:", data);

    return {
        leads: data || [],
        isLoading,
        isError,
        acceptLead: acceptMutation.mutate,
        declineLead: declineMutation.mutate,
    };
}
