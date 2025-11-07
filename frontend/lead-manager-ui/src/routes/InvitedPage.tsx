import ConfirmModal from "../components/ConfirmModal";
import { useLeads } from "../hooks/useLeads";
import LeadCard from "../components/LeadCard";
import LoadingSpinner from "../components/LoadingSpinner";
import EmptyState from "../components/EmptyState";

export default function InvitedPage() {
  const {
    leads,
    loading,
    handleAccept,
    handleDecline,
    confirmModal,
    handleConfirmAccept,
    setConfirmModal,
  } = useLeads("invited");

  if (loading) return <LoadingSpinner />;

  return (
    <div className="p-6">
      <h1 className="text-2xl font-semibold mb-4">Invited Leads</h1>
      {leads.length === 0 ? (
        <EmptyState message="No leads available." />
      ) : (
        <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-4">
          {leads.map((lead) => (
            <LeadCard
              key={lead.id}
              id={lead.id}
              firstName={lead.firstName}
              dateCreated={lead.dateCreated}
              category={lead.category}
              suburb={lead.suburb}
              description={lead.description}
              price={lead.price}
              status={lead.status}
              onAccept={() => handleAccept(lead.id)}
              onDecline={() => handleDecline(lead.id)}
            />
          ))}
        </div>
      )}

      {confirmModal && (
        <ConfirmModal
          message={confirmModal.message}
          suggestedPrice={confirmModal.suggestedPrice}
          onConfirm={() =>
            handleConfirmAccept(confirmModal.id, confirmModal.suggestedPrice)
          }
          onCancel={() => setConfirmModal(null)}
        />
      )}
    </div>
  );
}
