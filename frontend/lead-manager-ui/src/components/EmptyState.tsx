import { Inbox } from "lucide-react";

function EmptyState({ message }: { message: string }) {
  return (
    <div className="flex flex-col items-center justify-center text-gray-500 dark:text-gray-400 py-10">
      <Inbox size={40} className="mb-2" />
      <p>{message}</p>
    </div>
  );
}
export default EmptyState;
