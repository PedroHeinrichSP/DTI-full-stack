import LeadCard from "../components/LeadCard";
import EmptyState from "../components/EmptyState";
import LoadingSpinner from "../components/LoadingSpinner";
import { useLeads } from "../hooks/useLeads";

function InvitedPage() {
  const { leads, isLoading, isError, acceptLead, declineLead } = useLeads("invited");

  if (isLoading) { return <LoadingSpinner />; }
  if (isError) { return <EmptyState message="Error while loading leads. Please try again."/>; }
  if (!leads.length) { return <EmptyState message="No invited leads available." />; }

  return (
    <section className="max-w-6xl mx-auto p-4">
      {/* Cabeçalho da página */}
      <header className="mb-6">
        <h2 className="text-2xl font-bold mb-1">Invited Leads</h2>
        <p className="text-gray-600 dark:text-gray-400">
          Leads recebidos aguardando ação.
        </p>
      </header>

      {/* Lista de leads*/}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
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
            onAccept={() => acceptLead(lead.id)}
            onDecline={() => declineLead(lead.id)}
          />
        ))}
      </div>
    </section>
  );
}

export default InvitedPage;
