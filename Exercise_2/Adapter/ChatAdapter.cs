using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace Exercise_2.Adapter
{
    public class ChatAdapter : RecyclerView.Adapter
    {
        private readonly List<string> Messages;

        public ChatAdapter(List<string> messages)
        {
            Messages = messages;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is MessageViewHolder viewHolder) viewHolder.Message = Messages[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MessageItem, parent, false);
            return new MessageViewHolder(itemView);
        }

        public override int ItemCount => Messages.Count;
    }
}