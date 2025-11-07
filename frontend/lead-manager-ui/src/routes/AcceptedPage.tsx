import { useLeads } from "../hooks/useLeads";
import LeadCard from "../components/LeadCard";
import LoadingSpinner from "../components/LoadingSpinner";
import EmptyState from "../components/EmptyState";

export default function AcceptedPage() {
  const {
    leads,
    loading,
    handleAccept,
    handleDecline,
  } = useLeads("accepted");

  if (loading) return <LoadingSpinner />;

  return (
    <div className="p-6">
      <h1 className="text-2xl font-semibold mb-4">Accepted Leads</h1>
      {leads.length === 0 ? (
        <EmptyState message="No leads available." />
      ) : (
        <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-4">
          {leads.map((lead) => (
            <LeadCard
              key={lead.id}
              id={lead.id}
              firstName={lead.firstName}
              lastName={lead.lastName}
              dateCreated={lead.dateCreated}
              category={lead.category}
              suburb={lead.suburb}
              description={lead.description}
              price={lead.price}
              email={lead.email}
              phone={lead.phone}
              status={lead.status}
              onAccept={() => handleAccept(lead.id)}
              onDecline={() => handleDecline(lead.id)}
            />
          ))}
        </div>
      )}
    </div>
  );
}
