import LeadCard from "../components/LeadCard";
import EmptyState from "../components/EmptyState";
import LoadingSpinner from "../components/LoadingSpinner";
import { useLeads } from "../hooks/useLeads";

function AcceptedPage() {
  const { leads, isLoading, isError } = useLeads("accepted");
  
  if (isLoading) { return <LoadingSpinner />; }
  if (isError) { return <EmptyState message="Error while loading leads. Please try again."/>; }
  if (!leads.length) { return <EmptyState message="No accepted leads available." />; }

  return (
    <section className="max-w-6xl mx-auto p-4">
      {/* Cabeçalho da página */}
      <header className="mb-6">
        <h2 className="text-2xl font-bold mb-1">Accepted Leads</h2>
        <p className="text-gray-600 dark:text-gray-400">
          Leads aceitos aguardando ação.
        </p>
      </header>

      {/* Lista de leads*/}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
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
            discountedPrice={lead.discountedPrice}
            email={lead.email}
            phone={lead.phone}
            status={lead.status}
          />
        ))}
      </div>
    </section>
  );
}

export default AcceptedPage;
