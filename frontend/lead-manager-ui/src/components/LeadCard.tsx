import {
  MapPin,
  Briefcase,
  CalendarClock,
  Mail,
  Phone,
} from "lucide-react";

type LeadCardProps = {
  id: number;
  firstName: string;
  lastName?: string;
  dateCreated?: string;
  category: string;
  suburb: string;
  description: string;
  price: number;
  email?: string;
  phone?: string;
  status: "invited" | "accepted";
  onAccept?: () => void;
  onDecline?: () => void;
};

function LeadCard({
  id,
  firstName,
  lastName,
  dateCreated,
  category,
  suburb,
  description,
  price,
  email,
  phone,
  status,
  onAccept,
  onDecline,
}: LeadCardProps) {
  const avatar = firstName[0].toUpperCase();

  return (
    <div className="border border-gray-200 dark:border-gray-700 bg-white dark:bg-gray-800 rounded-xl p-4 sm:p-5 shadow-sm hover:shadow-md transition-all duration-200 flex flex-col justify-between">
      {/* Header */}
      <div className="flex items-center justify-between">
        <div className="flex items-center gap-3">
          <div className="w-10 h-10 rounded-full bg-orange-500 flex items-center justify-center text-white font-semibold">
            {avatar}
          </div>
          <div>
            <h3 className="font-semibold text-gray-900 dark:text-gray-100 leading-tight">
              {firstName} {lastName}
            </h3>
            {dateCreated && (
                <p className="flex items-center gap-1 text-xs text-gray-500 dark:text-gray-400">
                <CalendarClock size={14} />{" "}
                {(() => {
                  const d = new Date(dateCreated as string);
                  if (isNaN(d.getTime())) return dateCreated;
                  const datePart = d.toLocaleDateString(undefined, {
                  timeZone: "UTC",
                  month: "long",
                  day: "numeric",
                  year: "numeric",
                  });
                  const timePart = d
                  .toLocaleTimeString(undefined, {
                    timeZone: "UTC",
                    hour: "numeric",
                    minute: "2-digit",
                    hour12: true,
                  })
                  .toLowerCase();
                  return `${datePart} @ ${timePart}`;
                })()}
                </p>
            )}
          </div>
        </div>
        <span className="text-xs text-gray-500 dark:text-gray-400">#{id}</span>
      </div>

      {/* Details */}
      <div className="flex flex-wrap gap-x-4 gap-y-1 text-sm text-gray-600 dark:text-gray-300 mt-3">
        <p className="flex items-center gap-1"><MapPin size={14} />{suburb}</p>
        <p className="flex items-center gap-1"><Briefcase size={14} />{category}</p>
      </div>

      <p className="text-sm text-gray-700 dark:text-gray-300 mt-2 line-clamp-2">
        {description}
      </p>

      {status === "accepted" && (
        <div className="mt-2 text-sm text-gray-600 dark:text-gray-300">
          {phone && <p className="flex items-center gap-1"><Phone size={14} />{phone}</p>}
          {email && <p className="flex items-center gap-1"><Mail size={14} />{email}</p>}
        </div>
      )}

      {/* Footer */}
      <div className="flex flex-col sm:flex-row items-center justify-between gap-3 mt-3">
        {status === "invited" ? (
          <div className="flex w-full sm:w-auto gap-2">
            <button
              onClick={onAccept}
              className="flex-1 bg-orange-500 hover:bg-orange-600 text-white py-2 rounded-md font-medium transition-transform active:scale-95"
            >
              Accept
            </button>
            <button
              onClick={onDecline}
              className="flex-1 bg-gray-200 dark:bg-gray-700 text-gray-800 dark:text-gray-100 hover:bg-gray-300 dark:hover:bg-gray-600 rounded-md py-2 font-medium transition-transform active:scale-95"
            >
              Decline
            </button>
          </div>
        ) : (
          <span className="text-green-600 dark:text-green-400 font-semibold">
            Accepted
          </span>
        )}

        <div className="text-right">
            <span className="text-gray-800 dark:text-gray-200 font-semibold">
              ${price.toFixed(2)}
            </span>
          <p className="text-xs text-gray-500 dark:text-gray-400">Lead Invitation</p>
        </div>
      </div>
    </div>
  );
}

export default LeadCard;
export type { LeadCardProps };