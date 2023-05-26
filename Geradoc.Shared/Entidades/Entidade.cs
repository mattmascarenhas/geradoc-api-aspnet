using FluentValidator;

namespace Geradoc.Shared.Entidades {
    public abstract class Entidade: Notifiable {
        public Entidade() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
